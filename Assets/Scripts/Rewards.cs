using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Rewards : MonoBehaviour
{
    public static int reward = 0;
    public TextMeshProUGUI counterTMP;

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
        if (StaticHp.totalHP <= 0)
        {
            SceneManager.LoadScene("Jail Cutsceen");
        }
    }
}
