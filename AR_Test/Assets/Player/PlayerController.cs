using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG.Infrastructure.Utils.Swipe;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private SwipeListener swipeListener;
    PowerManager powerManager;

    private void OnEnable()
    {
        swipeListener.OnSwipe.AddListener(OnSwipe);
        swipeListener = FindObjectOfType<SwipeListener>();
        powerManager = GetComponent<PowerManager>();
    }
    private void OnSwipe(string swipe)
    {
        if(swipe == "Up")
        {
            powerManager.Flying();
        }
    }
    private void OnDisable()
    {
        swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }
}
