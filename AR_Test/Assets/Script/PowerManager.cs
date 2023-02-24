using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PowerManager : MonoBehaviour
{
    Rigidbody rbGolfy;
    [SerializeField] Transform cameraT;
    //[SerializeField] Vector3 parabola;
    [SerializeField] float parabolaForce;
    private void Start()
    {
        rbGolfy= GetComponent<Rigidbody>();
        //Flying();
    }
    public void Flying()
    {
        //parabola = new Vector3(cameraT.transform.position.x,cameraT.transform.position.y * parabolaForce, cameraT.transform.position.z * parabolaForce); 
        rbGolfy.AddForce(cameraT.transform.forward * parabolaForce, ForceMode.Impulse);
    }
}
