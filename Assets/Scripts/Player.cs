using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public GameManager gameManager;
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * 0.5f * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Input.GetAxis("Mouse X")<0)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z),.3f);
            }
            if (Input.GetAxis("Mouse X") > 0)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z), .3f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Carpma") || other.CompareTag("Toplama") || other.CompareTag("Cikartma") || other.CompareTag("Bolme"))
        {
            gameManager.AdamYonetim(other.tag,int.Parse(other.name),other.transform);
        }
    }
}
