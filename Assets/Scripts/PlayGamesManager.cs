using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using TMPro;
using System.Text;
using UnityEngine.SceneManagement;

public class PlayGamesManager : MonoBehaviour
{
    [Header("Inscribed")]
    [SerializeField] string fileName = "PlayerProfile";

    [Header("Dynamic")]
    public SaveData data;
    private static PlayGamesManager _instance;
    public static PlayGamesManager Instance {
        get {
            if (_instance == null) {
                _instance = FindFirstObjectByType<PlayGamesManager>();
                if (_instance == null) {
                    GameObject container = new GameObject("PlayGamesManager");
                    _instance = container.AddComponent<PlayGamesManager>();
                }
            }
            return _instance;
        }
    }
    public string playerName;
    public string id;
    public string imgURL;
    private bool isLoading = false;
    private bool isSaving = false;
    private bool isDeleting = false;

    void Start() {
        PlayGamesManager[] objs = FindObjectsByType<PlayGamesManager>(FindObjectsSortMode.None);

        if (objs.Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
        SignIn();
    }

    public void SignIn() {
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    internal void ProcessAuthentication(SignInStatus status) {
        if (status == SignInStatus.Success) {
            playerName = PlayGamesPlatform.Instance.GetUserDisplayName();
            id = PlayGamesPlatform.Instance.GetUserId();
            imgURL = PlayGamesPlatform.Instance.GetUserImageUrl();
            LoadData();
        }
    }

    // https://www.youtube.com/watch?v=O8Ipo2LnRk4
    public void SaveDataToJson() {
        if (!PlayGamesPlatform.Instance.localUser.authenticated) {
            Debug.LogWarning("User is not authenticated to Google Play Services");
            return;
        }

        if (isSaving) {
            Debug.LogWarning("Already saving data");
            return;
        }

        isSaving = true;

        PlayGamesPlatform.Instance.SavedGame.OpenWithAutomaticConflictResolution(
            fileName,
            DataSource.ReadCacheOrNetwork,
            ConflictResolutionStrategy.UseMostRecentlySaved,
            (status, metadata) => {
                if (status != SavedGameRequestStatus.Success) {
                    Debug.LogError("Error opening saved game");
                    isSaving = false;
                    return;
                }

                data = new SaveData {
                    bossHealth = StaticHp.totalHP,
                    currentMission = "MissionName",
                    currentMissionProgress = 0.5f
                };

                string jsonString = JsonUtility.ToJson(data);
                byte[] savedData = Encoding.ASCII.GetBytes(jsonString);

                SavedGameMetadataUpdate updatedMetadata = new SavedGameMetadataUpdate.Builder()
                    .WithUpdatedDescription("My Save File Description")
                    .Build();

                PlayGamesPlatform.Instance.SavedGame.CommitUpdate(
                    metadata,
                    updatedMetadata,
                    savedData,
                    (commitStatus, _) => {
                        isSaving = false;
                        if (commitStatus == SavedGameRequestStatus.Success) {
                            Debug.Log("Data saved successfully");
                        } else {
                            Debug.LogError("Error saving data");
                        }
                    }
                );
            }
        );
    }

    public void LoadData() {
        if (isLoading) {
            Debug.LogWarning("Load already in progress");
            return;
        }

        isLoading = true;

        PlayGamesPlatform.Instance.SavedGame.OpenWithAutomaticConflictResolution(
            fileName,
            DataSource.ReadCacheOrNetwork,
            ConflictResolutionStrategy.UseLongestPlaytime,
            (status, metadata) => {
                if (status != SavedGameRequestStatus.Success) {
                    Debug.LogError("Error opening saved game");
                    isLoading = false;
                    return;
                }

                PlayGamesPlatform.Instance.SavedGame.ReadBinaryData(
                    metadata,
                    (readStatus, savedData) => {
                        if (readStatus != SavedGameRequestStatus.Success) {
                            Debug.LogError("Error reading saved game data");
                            isLoading = false;
                            return;
                        }

                        string jsonString = Encoding.ASCII.GetString(savedData);
                        data = JsonUtility.FromJson<SaveData>(jsonString);

                        isLoading = false;
                    }
                );
            }
        );
    }
    
    public void DeleteData(SavedGameRequestStatus status) {
        if (isDeleting == true) {
            Debug.LogError("Delete already in progress");
            return;
        }

        isDeleting = true;

        PlayGamesPlatform.Instance.SavedGame.OpenWithAutomaticConflictResolution(
            fileName,
            DataSource.ReadCacheOrNetwork,
            ConflictResolutionStrategy.UseMostRecentlySaved,
            (status, metadata) => {
                if (status != SavedGameRequestStatus.Success) {
                    Debug.LogError("Error opening saved game");
                    isDeleting = false;
                    return;
                }
                PlayGamesPlatform.Instance.SavedGame.Delete(metadata);
                SceneManager.LoadScene(0);
            }
        );
    }
}

[System.Serializable]
public class SaveData {
    public int bossHealth;
    public string currentMission;
    public float currentMissionProgress;
}
