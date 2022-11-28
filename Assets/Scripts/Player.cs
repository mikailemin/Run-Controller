using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Player : MonoBehaviour
{


    public GameManager gameManager;
    public GameObject Kamera;
    public bool sonaGeldikMi;
    public GameObject gidecegiYer;
    public Slider slider;
    public GameObject gecisNoktasi;



    private void Start()
    {
        float fark = Vector3.Distance(transform.position, gecisNoktasi.transform.position);
        slider.maxValue=fark;
    }
    private void FixedUpdate()
    {
        if (!sonaGeldikMi)
            transform.Translate(Vector3.forward * 0.5f * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameManager.AnlikKarekterSayisi);
        

        if (sonaGeldikMi)
        {
            transform.position = Vector3.Lerp(transform.position, gidecegiYer.transform.position, 0.0125f);
            if (slider.value!=0)
            {
                slider.value -= 0.01f;
            }
        }
        else
        {
            float distance = Vector3.Distance(transform.position, gecisNoktasi.transform.position);
            
            slider.value = distance;



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
        else if (other.CompareTag("BosKarekter"))
        {
            gameManager.Karekterler.Add(other.gameObject);
            //GameManager.AnlikKarekterSayisi++;
           // other.gameObject.tag = "AltKarekterler";
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


