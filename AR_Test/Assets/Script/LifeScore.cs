using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeScore : MonoBehaviour
{
    public int score = 0;
    public TMP_Text text;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        text.text = "X " + score.ToString();

    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {

            case "Normal":

                score = score + 50;
                break;

            case "Critic":

                score = score + 100;
                break;

            case "InstaKill":

                break;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Acid")
        {
            score = score + 1;
        }


    }
}
