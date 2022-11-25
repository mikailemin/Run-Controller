using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 targetOffset;
    public bool sonaGeldikMi;
    public GameObject gidecegiYer;


    // Start is called before the first frame update
    void Start()
    {
        targetOffset = transform.position - target.position;
    }

   
    void LateUpdate()
    {
        if (!sonaGeldikMi)
            transform.position = Vector3.Lerp(transform.position, target.position + targetOffset, 0.125f);
        else
        {
            transform.position = Vector3.Lerp(transform.position, gidecegiYer.transform.position, 0.0125f);
        }
    }
}
