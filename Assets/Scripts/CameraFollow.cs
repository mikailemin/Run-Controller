using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 targetOffset;


    // Start is called before the first frame update
    void Start()
    {
        targetOffset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,target.position+targetOffset,0.125f);
    }
}
