using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Google.Play.Review;

public class Rewards : MonoBehaviour
{
    public static int reward = 0;
    public TextMeshProUGUI counterTMP;
    public ReviewManager _reviewManager = new ReviewManager();
    public PlayReviewInfo _playReviewInfo;

    void Update()
    {
        if (counterTMP == null)
        {
            return;
        }
        counterTMP.text = reward.ToString();
    }
    
    public void Gain()
    {
        reward += 50;
        PlayGamesManager.Instance.SaveData();
        if (StaticHp.totalHP > 0)
        {
            SceneManager.LoadScene("Quaid Base");
        }
        else if (StaticHp.totalHP <= 0)
        {
            StartCoroutine(RequestReview());
            Snooze.mission = true;
            Snooze.progress = false;
            Snooze.attack = false;
            Snooze.finish = false;
            Dashie.mission = true;
            Dashie.progress = false;
            Dashie.attack = false;
            Dashie.finish = false;
            Bruno.mission = true;
            Bruno.progress = false;
            Bruno.attack = false;
            Bruno.finish = false;
            Zippy.mission = true;
            Zippy.progress = false;
            Zippy.attack = false;
            Zippy.finish = false;
            NewStepCounter.lastStepOffset = 0;
            NewStepCounter.lastStepsTaken = 0;
            Calories.lastCaloriesBurned = 0;
            Calories.caloriesBurned = 0;
            Sleep.timeRemaining = 0;
            StaticHp.totalHP = 4;
            GameObject missionManager = GameObject.Find("MissionManager");
            GameObject musicObj = GameObject.Find("Music");
            if (musicObj != null) {
                AudioSource musicSource = musicObj.GetComponent<AudioSource>();
                if (musicSource != null) {
                    musicSource.Pause();
                }
            }
            if (missionManager != null) {
                Destroy(missionManager);
            } else {
                Debug.LogWarning("MissionManager GameObject not found. Nothing to destroy.");
            }
            GameObject.Find("Music").GetComponent<AudioSource>().Pause();
            PlayGamesManager.Instance.SaveData();
            SceneManager.LoadScene("Jail Cutsceen");
        }
    }

    IEnumerator RequestReview() {
        var requestFlowOperation = _reviewManager.RequestReviewFlow();
        yield return requestFlowOperation;
        if (requestFlowOperation.Error != ReviewErrorCode.NoError) {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }
        _playReviewInfo = requestFlowOperation.GetResult();
        var launchFlowOperation = _reviewManager.LaunchReviewFlow(_playReviewInfo);
        yield return launchFlowOperation;
        _playReviewInfo = null; // Reset the object
        if (launchFlowOperation.Error != ReviewErrorCode.NoError) {
            // Log error. For example, using launchFlowOperation.Error.ToString().
            yield break;
        }
        // The flow has finished. The API does not indicate whether the user
        // reviewed or not, or even whether the review dialog was shown. Thus, no
        // matter the result, we continue our app flow.
    }
}
