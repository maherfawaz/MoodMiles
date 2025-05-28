using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class RewardCount : MonoBehaviour
{
    public TextMeshProUGUI counterTMP;
    public int ree;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ree = Rewards.reward;
        counterTMP.text = ree.ToString();
    }
}
