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
        id = numberId;
        hatsOn = true;
        PlayGamesManager.Instance.SaveData();
    }
    public void BWears()
    {
        id = numberId;
        BhatsOn = true;
        PlayGamesManager.Instance.SaveData();
    }
    public void DWears()
    {
        id = numberId;
        DhatsOn = true;
        PlayGamesManager.Instance.SaveData();
    }
    public void ZWears()
    {
        id = numberId;
        ZhatsOn = true;
        PlayGamesManager.Instance.SaveData();
    }
    public void Unwears()
    {
        hatsOn = false;
        PlayGamesManager.Instance.SaveData();
    }
    public void BUnwears()
    {
        BhatsOn = false;
        PlayGamesManager.Instance.SaveData();
    }
    public void DUnwears()
    {
        DhatsOn = false;
        PlayGamesManager.Instance.SaveData();
    }
    public void ZUnwears()
    {
        ZhatsOn = false;
        PlayGamesManager.Instance.SaveData();
    }
}
