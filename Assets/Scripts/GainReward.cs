using UnityEngine;
using UnityEngine.SceneManagement;
public class GainReward : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Gain()
    {
        Rewards.reward += 50;
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
