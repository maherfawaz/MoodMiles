using UnityEngine;
using UnityEngine.UI;
public class Hat : MonoBehaviour
{
    public Image heldItem;
    public Sprite[] itemSprites;
    public static int id;
    public static bool hatsOn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        heldItem.sprite = itemSprites[id];
        if(hatsOn == true)
        {
            gameObject.SetActive(true);
        }
    }
}
