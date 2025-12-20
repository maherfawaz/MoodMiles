using System.Collections;
using UnityEngine;

public class AutoSaveManager : MonoBehaviour
{
    void Start() {
        StartCoroutine(AutoSaveCoroutine());
    }

    IEnumerator AutoSaveCoroutine() {
        while (true) {
            yield return new WaitForSeconds(10f);
            PlayGamesManager.Instance.SaveData();
        }
    }
}
