using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomIN : MonoBehaviour
{
    public GameObject Boom;// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Boom.gameObject.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Boom.gameObject.SetActive(false);
        }

    }
}
