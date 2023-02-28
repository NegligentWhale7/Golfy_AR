using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(Rigidbody))]
public class PowerManager : MonoBehaviour
{
    Rigidbody rbGolfy;
    [SerializeField] GameObject cameraT;
    //[SerializeField] Vector3 parabola;
    [SerializeField] float powerValue, waitingTime;
    [SerializeField] Slider powerSlider;
    Vector3 initialPosition;
    private void Start()
    {
        rbGolfy = GetComponent<Rigidbody>();
        cameraT = GameObject.FindGameObjectWithTag("MainCamera");
        initialPosition = transform.position;
        //Flying();
    }
    public void Flying()
    {
        GetForce();
        //parabola = new Vector3(cameraT.transform.position.x,cameraT.transform.position.y * parabolaForce, cameraT.transform.position.z * parabolaForce); 
        rbGolfy.AddForce(cameraT.transform.forward * powerValue, ForceMode.Impulse);
    }
    public void GetForce()
    {
        powerValue = powerSlider.value;
        Debug.Log(powerValue);
        StartCoroutine(RestartPosition(waitingTime));
    }
    private IEnumerator RestartPosition(float time)
    {
        yield return new WaitForSeconds(time);
        transform.position = initialPosition;
    }
}
