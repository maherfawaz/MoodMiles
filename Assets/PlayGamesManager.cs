using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;

public class PlayGamesManager : MonoBehaviour
{
    public string playerName;
    public string id;
    public string imgURL;
    public Text text;

    void Start() {
        text = GameObject.Find("Text").GetComponent<Text>();
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
            text.text = $"Welcome, {playerName}!";
        } else {
            text.text = "Sign-in failed!";
        }
    }
}
