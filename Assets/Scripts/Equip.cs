using UnityEngine;

public class Equip : MonoBehaviour
{

    public int numberId;

    public void Wears()
    {
        Hat.id = numberId;
        Hat.hatsOn = true;
        PlayGamesManager.Instance.SaveData();
    }
    public void BWears()
    {
        Hat.id = numberId;
        Hat.BhatsOn = true;
        PlayGamesManager.Instance.SaveData();
    }
    public void DWears()
    {
        Hat.id = numberId;
        Hat.DhatsOn = true;
        PlayGamesManager.Instance.SaveData();
    }
    public void ZWears()
    {
        Hat.id = numberId;
        Hat.ZhatsOn = true;
        PlayGamesManager.Instance.SaveData();
    }
    public void Unwears()
    {
        Hat.hatsOn = false;
        PlayGamesManager.Instance.SaveData();
    }
    public void BUnwears()
    {
        Hat.BhatsOn = false;
        PlayGamesManager.Instance.SaveData();
    }
    public void DUnwears()
    {
        Hat.DhatsOn = false;
        PlayGamesManager.Instance.SaveData();
    }
    public void ZUnwears()
    {
        Hat.ZhatsOn = false;
        PlayGamesManager.Instance.SaveData();
    }
}
