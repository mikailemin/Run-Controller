using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{


    public GameManager gameManager;
    public GameObject Kamera;
    public bool sonaGeldikMi;
    public GameObject gidecegiYer;

    private void FixedUpdate()
    {
        if (!sonaGeldikMi)
            transform.Translate(Vector3.forward * 0.5f * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (sonaGeldikMi)
        {
            transform.position = Vector3.Lerp(transform.position, gidecegiYer.transform.position, 0.0125f);
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Input.GetAxis("Mouse X") < 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z), .3f);
                }
                if (Input.GetAxis("Mouse X") > 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z), .3f);
                }
            }

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Carpma") || other.CompareTag("Toplama") || other.CompareTag("Cikartma") || other.CompareTag("Bolme"))
        {
            gameManager.AdamYonetim(other.tag, int.Parse(other.name), other.transform);
        }
        else if (other.CompareTag("SonTetikleyici"))
        {
            Kamera.GetComponent<CameraFollow>().sonaGeldikMi = true;
            gameManager.DusmanlariTetikle();
            sonaGeldikMi = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Direk") || collision.gameObject.CompareTag("igneliKutu"))
        {

            if (transform.position.x>0)
            {
                transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
            }
           
        }
    }


}


