using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeScore : MonoBehaviour
{
    public int score = 0;
    public TMP_Text text;
    public AudioSource golpe;
    
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
                golpe.Play();
                break;

            case "Critic":

                score = score + 100;
                golpe.Play();
                break;

            case "InstaKill":

                break;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Acid")
        {
            score = score + 1;
        }


    }
}
