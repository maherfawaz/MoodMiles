using System.Collections;
using UnityEngine;
using Google.Play.Review;

public class PlayReviewManager : MonoBehaviour
{
    public ReviewManager _reviewManager = new ReviewManager();
    public PlayReviewInfo _playReviewInfo;
    private static PlayReviewManager _instance;
    public static PlayReviewManager Instance {
        get {
            if (_instance == null) {
                _instance = FindFirstObjectByType<PlayReviewManager>();
                if (_instance == null) {
                    GameObject container = new GameObject("PlayReviewManager");
                    _instance = container.AddComponent<PlayReviewManager>();
                }
            }
            return _instance;
        }
    }

    void Start() {
        PlayReviewManager[] objs = FindObjectsByType<PlayReviewManager>(FindObjectsSortMode.None);
        if (objs.Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public IEnumerator RequestReview() {
        var requestFlowOperation = _reviewManager.RequestReviewFlow();
        yield return requestFlowOperation;
        if (requestFlowOperation.Error != ReviewErrorCode.NoError) {
            Debug.LogError($"RequestReviewFlow failed: {requestFlowOperation.Error}");
            yield break;
        }
        _playReviewInfo = requestFlowOperation.GetResult();
        var launchFlowOperation = _reviewManager.LaunchReviewFlow(_playReviewInfo);
        yield return launchFlowOperation;
        _playReviewInfo = null; // Reset the object
        if (launchFlowOperation.Error != ReviewErrorCode.NoError) {
            Debug.LogError($"LaunchReviewFlow failed: {launchFlowOperation.Error}");
            yield break;
        }
        // The flow has finished. The API does not indicate whether the user
        // reviewed or not, or even whether the review dialog was shown. Thus, no
        // matter the result, we continue our app flow.
    }
}
