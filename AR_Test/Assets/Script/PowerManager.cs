using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(Rigidbody))]
public class PowerManager : MonoBehaviour
{
    [Header("General values")]
    [SerializeField] GameObject cameraT;
    //[SerializeField] Vector3 parabola;
    [SerializeField] float powerValue, waitingTime;
    [SerializeField] Slider powerSlider;
    [SerializeField] Transform spawnPos;
    Rigidbody rbGolfy;
    public bool isFlying = false;

    [Header("Parabolic Values")]
    [SerializeField] float maxHeight;
    float initialVelocity = 0.1f, time, maxDistance, angle = 45f, vX, t, vY;
    private void Start()
    {
        rbGolfy = GetComponent<Rigidbody>();
        //cameraT = GameObject.FindGameObjectWithTag("MainCamera");
        //Flying();
    }
    public void Flying()
    {
        GetForce();
        //parabola = new Vector3(cameraT.transform.position.x,cameraT.transform.position.y * parabolaForce, cameraT.transform.position.z * parabolaForce); 
        vY = Mathf.Sqrt(2f * maxHeight * -Physics.gravity.y);
        /*t = 2f * vY / -Physics.gravity.y;
        vX = maxDistance / t;
        Vector3 direction = new Vector3(vX, vY, vX);
        rbGolfy.velocity = rbGolfy.transform.InverseTransformPoint(direction);*/

        Vector3 direction = rbGolfy.transform.position - cameraT.transform.position;
        rbGolfy.AddForce(new Vector3(direction.x * powerValue, vY, direction.z * powerValue), ForceMode.Impulse);
        //rbGolfy.AddForce((rbGolfy.transform.InverseTransformPoint(direction)), ForceMode.Impulse);
        //rbGolfy.AddForce(direction.normalized * powerValue, ForceMode.Impulse);
        isFlying = true;
    }
    public void GetForce()
    {
        powerValue = powerSlider.value;
        maxDistance = 2;
        maxHeight = powerValue * 2;
        //Debug.Log(powerValue);
        StartCoroutine(RestartPosition(waitingTime));
    }
    public void LookingAtCamera()
    {
        transform.LookAt(cameraT.transform.position);
    }
    public void CheckConstrains()
    {
        if (!isFlying)
        {
            rbGolfy.constraints = RigidbodyConstraints.FreezePositionX;
            rbGolfy.constraints = RigidbodyConstraints.FreezePositionZ;
            rbGolfy.constraints = RigidbodyConstraints.FreezeRotationX;
            rbGolfy.constraints = RigidbodyConstraints.FreezeRotationY;
            rbGolfy.constraints = RigidbodyConstraints.FreezeRotationZ;
        }
        else
        {
            rbGolfy.constraints = RigidbodyConstraints.None;
        }
    }
    private IEnumerator RestartPosition(float time)
    {
        yield return new WaitForSeconds(time);
        //transform.position = spawnPos.position;
        Vector3 newPos = spawnPos.position;
        Mathf.Clamp(newPos.y, 15f, 30f);
        transform.position = newPos;
        isFlying = false;
        StopAllCoroutines();
    }
}
