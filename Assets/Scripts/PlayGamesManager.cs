using System;
using System.Text;
using System.Collections;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using Google.Play.Common;
using Google.Play.AppUpdate;
using TMPro;

public class PlayGamesManager : MonoBehaviour
{
    [Header("Inscribed")]
    [SerializeField] string fileName = "PlayerProfile";
    public TextMeshProUGUI text;
    public string[] permissions = {
        "android.permission.ACTIVITY_RECOGNITION",
        "android.permission.RECORD_AUDIO"
    };
    public static bool devMode;

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
    public AppUpdateManager appUpdateManager = new AppUpdateManager();
    public string playerName;
    public string id;
    public string imgURL;
    public bool permissionGranted = false;
    public bool loadedFromCloud = false;
    public bool loadedFromLocal = false;
    private bool isLoading = false;
    private bool isSaving = false;
    private bool isDeleting = false;
    private bool isSigningIn = false;
    private bool canStart = false;

    void Start() {
        //RefreshRate refreshRate = Screen.currentResolution.refreshRateRatio;
        //Application.targetFrameRate = (int)refreshRate.numerator;
        //Application.targetFrameRate = 200;

        if (Application.isEditor) {
            Debug.Log("Running in Editor - Play Games Disabled");
            canStart = true;
            text.text = "Tap to Start";
            return;
        }

        PlayGamesManager[] objs = FindObjectsByType<PlayGamesManager>(FindObjectsSortMode.None);
        if (objs.Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
        
        if (Application.internetReachability != NetworkReachability.NotReachable) {
            StartCoroutine(CheckInternetConnection((isConnected) => {
                if (isConnected) {
                    StartCoroutine(CheckForUpdate());
                    SignIn();
                }
            }));
        }
        
        LoadData();
    }

    // https://www.youtube.com/watch?v=xqcljLgQdGQ
    IEnumerator CheckInternetConnection(System.Action<bool> callback) {
        UnityWebRequest www = UnityWebRequest.Get("https://www.google.com");
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success) {
            Debug.Log("Internet is reachable");
            callback(true);
        } else {
            Debug.Log("Internet is not reachable: " + www.error);
            callback(false);
        }
    }

    public void SignIn() {
        if (isSigningIn) return;
        isSigningIn = true;
        text.text = "Signing in...";
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    internal void ProcessAuthentication(SignInStatus status) {
        if (status == SignInStatus.Success) {
            playerName = PlayGamesPlatform.Instance.GetUserDisplayName();
            id = PlayGamesPlatform.Instance.GetUserId();
            imgURL = PlayGamesPlatform.Instance.GetUserImageUrl();
            isSigningIn = false;
            LoadData();
        } else {
            isSigningIn = false;
            LoadData();
        }
    }

    // https://www.youtube.com/watch?v=O8Ipo2LnRk4
    // https://www.youtube.com/watch?v=0KDU_SzrCkA
    public void SaveData() {
        if (isSaving) {
            Debug.LogWarning("Already saving data");
            return;
        }

        if (Application.isEditor) {
            return;
        }

        isSaving = true;
        
        data = new SaveData {
            bossHealth = StaticHp.totalHP,
            sleepTimeRemaining = Sleep.timeRemaining,
            sleepGoal = Sleep.hours,
            breathGoal = Breathing.breathTimer,
            lastStepsTaken = NewStepCounter.lastStepsTaken,
            lastStepOffset = NewStepCounter.lastStepOffset,
            stepGoal = NewStepCounter.stepGoal,
            caloriesBurned = Calories.lastCaloriesBurned,
            caloriesGoal = Calories.caloriesGoal,
            weightKg = Calories.weightKg,
            rewards = Rewards.reward,
            hatId = Hat.id,
            hatUnlocked = Hat.hatUnlocked,
            trueIntro = TrueIntro.trueIntro,
            brunoIntro = Bruno.intro,
            brunoMission = Bruno.mission,
            brunoProgress = Bruno.progress,
            brunoAttack = Bruno.attack,
            brunoFinish = Bruno.finish,
            brunoSkip = Bruno.skipTu,
            brunoHat = Hat.BhatsOn,
            snoozeIntro = Snooze.intro,
            snoozeMission = Snooze.mission,
            snoozeProgress = Snooze.progress,
            snoozeAttack = Snooze.attack,
            snoozeFinish = Snooze.finish,
            snoozeSkip = Snooze.skipTu,
            snoozeHat = Hat.hatsOn,
            dashIntro = Dashie.intro,
            dashMission = Dashie.mission,
            dashProgress = Dashie.progress,
            dashAttack = Dashie.attack,
            dashFinish = Dashie.finish,
            dashSkip = Dashie.skipTu,
            dashHat = Hat.DhatsOn,
            zippyIntro = Zippy.intro,
            zippyMission = Zippy.mission,
            zippyProgress = Zippy.progress,
            zippyAttack = Zippy.attack,
            zippyFinish = Zippy.finish,
            zippySkip = Zippy.skipTu,
            zippyHat = Hat.ZhatsOn
        };
        
        string jsonString = JsonUtility.ToJson(data);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, fileName + ".json"), jsonString);

        if (PlayGamesPlatform.Instance.localUser.authenticated) {
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

                    byte[] savedData = Encoding.ASCII.GetBytes(jsonString);

                    SavedGameMetadataUpdate updatedMetadata = new SavedGameMetadataUpdate.Builder()
                        .WithUpdatedDescription($"{id} - {playerName} - {DateTime.Now}")
                        .Build();

                    PlayGamesPlatform.Instance.SavedGame.CommitUpdate(
                        metadata,
                        updatedMetadata,
                        savedData,
                        (commitStatus, _) => {
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
        isSaving = false;
    }

    void LoadData() {
        if (isLoading) {
            Debug.LogWarning("Load already in progress");
            return;
        }

        if (Application.isEditor) {
            return;
        }

        isLoading = true;
        text.text = "Loading Data...";

        if (PlayGamesPlatform.Instance.localUser.authenticated) {
            PlayGamesPlatform.Instance.SavedGame.OpenWithAutomaticConflictResolution(
                fileName,
                DataSource.ReadCacheOrNetwork,
                ConflictResolutionStrategy.UseLongestPlaytime,
                (status, metadata) => {
                    if (status != SavedGameRequestStatus.Success) {
                        Debug.LogError("Error opening saved game");
                        LoadData2();
                        return;
                    }

                    PlayGamesPlatform.Instance.SavedGame.ReadBinaryData(
                        metadata,
                        (readStatus, savedData) => {
                            if (readStatus != SavedGameRequestStatus.Success || savedData == null || savedData.Length == 0) {
                                Debug.LogError("Error reading saved game data");
                                LoadData2();
                                return;
                            }
                            
                            // As suggested by Google Gemini and improved by GitHub Copilot
                            if (File.Exists(Path.Combine(Application.persistentDataPath, fileName + ".json"))) {
                                DateTime localFileTime = File.GetLastWriteTimeUtc(Path.Combine(Application.persistentDataPath, fileName + ".json"));
                                DateTime cloudFileTime = metadata.LastModifiedTimestamp;
                                if (localFileTime > cloudFileTime) {
                                    Debug.Log("Local data is newer, using local data");
                                    LoadData2();
                                    return;
                                } else {
                                    Debug.Log("Cloud data is newer, using cloud data");
                                }
                            }

                            string jsonString = Encoding.ASCII.GetString(savedData);
                            data = JsonUtility.FromJson<SaveData>(jsonString);
                            loadedFromCloud = true;
                            LoadData2();
                        }
                    );
                }
            );
        } else {
            LoadData2();
        }
    }
    
    void LoadData2() {
        if (!loadedFromCloud) {
            if (File.Exists(Path.Combine(Application.persistentDataPath, fileName + ".json"))) {
                string jsonString = File.ReadAllText(Path.Combine(Application.persistentDataPath, fileName + ".json"));
                if (!string.IsNullOrEmpty(jsonString)) {
                    data = JsonUtility.FromJson<SaveData>(jsonString);
                    loadedFromLocal = true;
                }
            } else {
                isLoading = false;
                canStart = true;
                text.text = "Tap to Start";
                return;
            }
        }

        if (loadedFromCloud || loadedFromLocal) {
            StaticHp.totalHP = data.bossHealth;
            Sleep.timeRemaining = data.sleepTimeRemaining;
            Sleep.hours = data.sleepGoal;
            Breathing.breathTimer = data.breathGoal;
            NewStepCounter.lastStepsTaken = data.lastStepsTaken;
            NewStepCounter.lastStepOffset = data.lastStepOffset;
            NewStepCounter.stepGoal = data.stepGoal;
            Calories.lastCaloriesBurned = data.caloriesBurned;
            Calories.caloriesGoal = data.caloriesGoal;
            Calories.weightKg = data.weightKg;
            Rewards.reward = data.rewards;
            Hat.id = data.hatId;
            Hat.hatUnlocked = data.hatUnlocked;
            TrueIntro.trueIntro = data.trueIntro;
            Bruno.intro = data.brunoIntro;
            Bruno.mission = data.brunoMission;
            Bruno.progress = data.brunoProgress;
            Bruno.attack = data.brunoAttack;
            Bruno.finish = data.brunoFinish;
            Bruno.skipTu = data.brunoSkip;
            Hat.BhatsOn = data.brunoHat;
            Snooze.intro = data.snoozeIntro;
            Snooze.mission = data.snoozeMission;
            Snooze.progress = data.snoozeProgress;
            Snooze.attack = data.snoozeAttack;
            Snooze.finish = data.snoozeFinish;
            Snooze.skipTu = data.snoozeSkip;
            Hat.hatsOn = data.snoozeHat;
            Dashie.intro = data.dashIntro;
            Dashie.mission = data.dashMission;
            Dashie.progress = data.dashProgress;
            Dashie.attack = data.dashAttack;
            Dashie.finish = data.dashFinish;
            Dashie.skipTu = data.dashSkip;
            Hat.DhatsOn = data.dashHat;
            Zippy.intro = data.zippyIntro;
            Zippy.mission = data.zippyMission;
            Zippy.progress = data.zippyProgress;
            Zippy.attack = data.zippyAttack;
            Zippy.finish = data.zippyFinish;
            Zippy.skipTu = data.zippySkip;
            Hat.ZhatsOn = data.zippyHat;
        }
        
        isLoading = false;
        canStart = true;
        text.text = "Tap to Start";
    }

    public void DeleteData() {
        if (isDeleting) {
            Debug.LogError("Delete already in progress");
            return;
        }

        isDeleting = true;
        text.text = "Deleting...";

        if (File.Exists(Path.Combine(Application.persistentDataPath, fileName + ".json"))) {
            File.Delete(Path.Combine(Application.persistentDataPath, fileName + ".json"));
        }

        if (PlayGamesPlatform.Instance.localUser.authenticated) {
            Debug.Log("Deleting saved game from cloud: " + fileName);
            PlayGamesPlatform.Instance.SavedGame.OpenWithAutomaticConflictResolution(
                fileName,
                DataSource.ReadCacheOrNetwork,
                ConflictResolutionStrategy.UseMostRecentlySaved,
                (status, metadata) => {
                    if (status != SavedGameRequestStatus.Success) {
                        Debug.LogError("Error opening saved game");
                        isDeleting = false;
                        text.text = "Tap to Start";
                        return;
                    }
                    PlayGamesPlatform.Instance.SavedGame.Delete(metadata);
                    Debug.Log("Saved game deleted successfully");
                    Application.Quit();
                }
            );
        } else {
            Application.Quit();
        }
    }

    public void Launch() {
        if (isLoading || isDeleting || isSigningIn || !canStart) {
            return;
        }
        
        if (playerName == "st0rmyrat" || Application.isEditor) {
            Rewards.reward = 200;
            devMode = true;
        }
        
        if (!permissionGranted) {
            text.text = "Permissions needed to continue";
            RequestPermissions();
            return;
        }
        
        if (TrueIntro.trueIntro) {
            SceneManager.LoadScene(19);
        } else {
            SceneManager.LoadScene(1);
        }
    }

    IEnumerator CheckForUpdate() {
        PlayAsyncOperation<AppUpdateInfo, AppUpdateErrorCode> appUpdateInfoOperation =
            appUpdateManager.GetAppUpdateInfo();

        // Wait until the asynchronous operation completes.
        yield return appUpdateInfoOperation;

        if (appUpdateInfoOperation.IsSuccessful) {
            var appUpdateInfoResult = appUpdateInfoOperation.GetResult();
            // Check AppUpdateInfo's UpdateAvailability, UpdatePriority,
            // IsUpdateTypeAllowed(), ... and decide whether to ask the user
            // to start an in-app update.
            
            if (appUpdateInfoOperation.GetResult().UpdateAvailability != UpdateAvailability.UpdateAvailable) {
                yield break;
            }
            
            // Creates an AppUpdateOptions defining a flexible in-app
            // update flow and its parameters.
            var appUpdateOptions = AppUpdateOptions.FlexibleAppUpdateOptions();
            // Creates an AppUpdateRequest that can be used to monitor the
            // requested in-app update flow.
            var startUpdateRequest = appUpdateManager.StartUpdate(
            // The result returned by PlayAsyncOperation.GetResult().
            appUpdateInfoResult,
            // The AppUpdateOptions created defining the requested in-app update
            // and its parameters.
            appUpdateOptions);

            while (!startUpdateRequest.IsDone) {
                // For flexible flow, the user can continue to use the app while
                // the update downloads in the background. You can implement a
                // progress bar showing the download status during this time.
                yield return null;
            }
        } else {
            // Log appUpdateInfoOperation.Error.
        }
    }
    
    async void RequestPermissions() {
#if UNITY_EDITOR
        Debug.Log("Editor Platform");
        permissionGranted = true;
        Launch();
#endif
#if UNITY_ANDROID
        AndroidRuntimePermissions.Permission[] results = await AndroidRuntimePermissions.RequestPermissionsAsync(permissions);
        if (results.All(r => r == AndroidRuntimePermissions.Permission.Granted)) {
            permissionGranted = true;
            Launch();
            Debug.Log("All permissions granted");
        } else if (results.Any(r => r == AndroidRuntimePermissions.Permission.Denied)) {
            text.text = "Permissions needed to continue";
            AndroidRuntimePermissions.OpenSettings();
        } else if (results.Any(r => r == AndroidRuntimePermissions.Permission.ShouldAsk)){
            text.text = "Permissions needed to continue";
            Debug.Log("Some permissions denied");
        }
#endif
    }

    /*void OnApplicationPause(bool pause) {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (!pause && SceneManager.GetActiveScene().buildIndex != 0) {
            if (AndroidRuntimePermissions.CheckPermissions(permissions).Any(p => p != AndroidRuntimePermissions.Permission.Granted)) {
                permissionGranted = false;
                Destroy(GameObject.Find("MissionManager"));
                SceneManager.LoadScene(0);
            }
        }
#endif
    }*/
}

[Serializable]
public class SaveData {
    public int bossHealth;
    public float sleepTimeRemaining;
    public float sleepGoal;
    public float breathGoal;
    public long lastStepsTaken;
    public long lastStepOffset;
    public long stepGoal;
    public int caloriesBurned;
    public int caloriesGoal;
    public int weightKg;
    public int rewards;
    public int hatId;
    public bool hatUnlocked;
    public bool trueIntro;
    public bool brunoIntro;
    public bool brunoMission;
    public bool brunoProgress;
    public bool brunoAttack;
    public bool brunoFinish;
    public bool brunoSkip;
    public bool brunoHat;
    public bool snoozeIntro;
    public bool snoozeMission;
    public bool snoozeProgress;
    public bool snoozeAttack;
    public bool snoozeFinish;
    public bool snoozeSkip;
    public bool snoozeHat;
    public bool dashIntro;
    public bool dashMission;
    public bool dashProgress;
    public bool dashAttack;
    public bool dashFinish;
    public bool dashSkip;
    public bool dashHat;
    public bool zippyIntro;
    public bool zippyMission;
    public bool zippyProgress;
    public bool zippyAttack;
    public bool zippyFinish;
    public bool zippySkip;
    public bool zippyHat;
}
