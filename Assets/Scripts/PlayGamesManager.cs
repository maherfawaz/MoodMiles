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
    public void SaveData() {
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
                    rewards = Rewards.reward,
                    trueIntro = TrueIntro.trueIntro,
                    brunoIntro = Bruno.intro,
                    brunoMission = Bruno.mission,
                    brunoProgress = Bruno.progress,
                    brunoAttack = Bruno.attack,
                    brunoFinish = Bruno.finish,
                    brunoSkip = Bruno.skipTu,
                    snoozeIntro = SnoozeInro.intro,
                    snoozeMission = SnoozeInro.mission,
                    snoozeProgress = SnoozeInro.progress,
                    snoozeAttack = SnoozeInro.attack,
                    snoozeFinish = SnoozeInro.finish,
                    snoozeSkip = SnoozeInro.skipTu,
                    dashIntro = Dashie.intro,
                    dashMission = Dashie.mission,
                    dashProgress = Dashie.progress,
                    dashAttack = Dashie.attack,
                    dashFinish = Dashie.finish,
                    dashSkip = Dashie.skipTu,
                    zippyIntro = Zippy.intro,
                    zippyMission = Zippy.mission,
                    zippyAttack = Zippy.attack,
                    zippyFinish = Zippy.finish,
                    zippySkip = Zippy.skipTu,
                };

                string jsonString = JsonUtility.ToJson(data);
                byte[] savedData = Encoding.ASCII.GetBytes(jsonString);

                SavedGameMetadataUpdate updatedMetadata = new SavedGameMetadataUpdate.Builder()
                    .WithUpdatedDescription($"{id} - {playerName} - {System.DateTime.Now}")
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
                        StaticHp.totalHP = data.bossHealth;
                        Rewards.reward = data.rewards;
                        TrueIntro.trueIntro = data.trueIntro;
                        Bruno.intro = data.brunoIntro;
                        Bruno.mission = data.brunoMission;
                        Bruno.progress = data.brunoProgress;
                        Bruno.attack = data.brunoAttack;
                        Bruno.finish = data.brunoFinish;
                        Bruno.skipTu = data.brunoSkip;
                        SnoozeInro.intro = data.snoozeIntro;
                        SnoozeInro.mission = data.snoozeMission;
                        SnoozeInro.progress = data.snoozeProgress;
                        SnoozeInro.attack = data.snoozeAttack;
                        SnoozeInro.finish = data.snoozeFinish;
                        SnoozeInro.skipTu = data.snoozeSkip;
                        Dashie.intro = data.dashIntro;
                        Dashie.mission = data.dashMission;
                        Dashie.progress = data.dashProgress;
                        Dashie.attack = data.dashAttack;
                        Dashie.finish = data.dashFinish;
                        Dashie.skipTu = data.dashSkip;
                        Zippy.intro = data.zippyIntro;
                        Zippy.mission = data.zippyMission;
                        Zippy.attack = data.zippyAttack;
                        Zippy.finish = data.zippyFinish;
                        Zippy.skipTu = data.zippySkip;

                        isLoading = false;
                    }
                );
            }
        );
    }
    
    public void DeleteData() {
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
                Application.Quit();
            }
        );
    }
}

[System.Serializable]
public class SaveData {
    public int bossHealth;
    public float sleepGoal;
    public float breathGoal;
    public long stepGoal;
    public int caloriesGoal;
    public int weightKg;
    public int rewards;
    public bool trueIntro;
    public bool brunoIntro;
    public bool brunoMission;
    public bool brunoProgress;
    public bool brunoAttack;
    public bool brunoFinish;
    public bool brunoSkip;
    public bool snoozeIntro;
    public bool snoozeMission;
    public bool snoozeProgress;
    public bool snoozeAttack;
    public bool snoozeFinish;
    public bool snoozeSkip;
    public bool dashIntro;
    public bool dashMission;
    public bool dashProgress;
    public bool dashAttack;
    public bool dashFinish;
    public bool dashSkip;
    public bool zippyIntro;
    public bool zippyMission;
    public bool zippyAttack;
    public bool zippyFinish;
    public bool zippySkip;
}
