using UnityEngine;
using UnityEngine.UI;
public class Hat : MonoBehaviour
{
    public Image heldItem;
    public Sprite[] itemSprites;
    public int numberId;
    public static int id;
    public static bool hatsOn = false;
    public static bool BhatsOn = false;
    public static bool ZhatsOn = false;
    public static bool DhatsOn = false;
    public static bool hatUnlocked = false;

    void Update()
    {
        heldItem.sprite = itemSprites[id];
        if (hatsOn == true)
        {
            gameObject.SetActive(true);
        }
    }
    public void Wears()
    {
        if (Rewards.reward >= 200 || hatUnlocked) {
            if (Rewards.reward >= 200 && !hatUnlocked) {
                Rewards.reward -= 200;
            }
            id = numberId;
            hatsOn = true;
            hatUnlocked = true;
        }
    }
    public void BWears()
    {
        if (Rewards.reward >= 200 || hatUnlocked) {
            if (Rewards.reward >= 200 && !hatUnlocked) {
                Rewards.reward -= 200;
            }
            id = numberId;
            BhatsOn = true;
            hatUnlocked = true;
        }
    }
    public void DWears()
    {
        if (Rewards.reward >= 200 || hatUnlocked) {
            if (Rewards.reward >= 200 && !hatUnlocked) {
                Rewards.reward -= 200;
            }
            id = numberId;
            DhatsOn = true;
            hatUnlocked = true;
        }
    }
    public void ZWears()
    {
        if (Rewards.reward >= 200 || hatUnlocked) {
            if (Rewards.reward >= 200 && !hatUnlocked) {
                Rewards.reward -= 200;
            }
            id = numberId;
            ZhatsOn = true;
            hatUnlocked = true;
        }
    }
    public void Unwears()
    {
        hatsOn = false;
    }
    public void BUnwears()
    {
        BhatsOn = false;
    }
    public void DUnwears()
    {
        DhatsOn = false;
    }
    public void ZUnwears()
    {
        ZhatsOn = false;
    }
}
