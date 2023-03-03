using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GolfyDialogs : MonoBehaviour
{
    [SerializeField] PowerManager powerManager;
    [SerializeField] List<TextMeshProUGUI> golfysDialogs = new List<TextMeshProUGUI>();
    [SerializeField] float time;
    bool isTalking = false;
    int random;
    private void Update()
    {
        if(!isTalking && !powerManager.isFlying) { ShowDialog(); }
        if (powerManager.isFlying)
        {
            StopAllCoroutines();
            golfysDialogs[random].gameObject.SetActive(false);
            isTalking = false;
        }
    }
    public void ShowDialog()
    {
        isTalking = true;
        if (!powerManager.isFlying)
        {
            StartCoroutine(ShowInsult(time));
        }
        if (powerManager.isFlying) StopAllCoroutines();
    }
    public IEnumerator ShowInsult(float time)
    {
            random = Random.Range(0, golfysDialogs.Count);
            golfysDialogs[random].gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(time);
            golfysDialogs[random].gameObject.SetActive(false);
            isTalking= false;
    }
}
