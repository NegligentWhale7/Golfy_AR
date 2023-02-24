using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(Rigidbody))]
public class PowerManager : MonoBehaviour
{
    Rigidbody rbGolfy;
    [SerializeField] GameObject cameraT;
    //[SerializeField] Vector3 parabola;
    [SerializeField] float parabolaForce;
    private void Start()
    {
        rbGolfy= GetComponent<Rigidbody>();
        cameraT = GameObject.FindGameObjectWithTag("MainCamera");
        //Flying();
    }
    public void Flying()
    {
        //parabola = new Vector3(cameraT.transform.position.x,cameraT.transform.position.y * parabolaForce, cameraT.transform.position.z * parabolaForce); 
        rbGolfy.AddForce(cameraT.transform.forward * parabolaForce, ForceMode.Impulse);
    }
}
