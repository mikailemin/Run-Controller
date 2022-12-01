using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using mikail;
using System;

public class AnaMenuManager : MonoBehaviour
{
    BellekYonetim bellekYonetim=new BellekYonetim();
    public GameObject cikisPaneli;
    void Start()
    {
        bellekYonetim.KontrolEtveTanimla();
    }

   
    public void SahneYukle(int index)
    {

        SceneManager.LoadScene(index);

    }
    public void Oyna()
    {
        SceneManager.LoadScene(bellekYonetim.VeriOku_I("SonLevel"));
       
    }

    public void Cikis()
    {
        cikisPaneli.SetActive(true);
    }

    public void CikisDurumuCek(string durum)
    {
        if (durum=="Evet")
        {
            Application.Quit();
        }
        else
        {
            cikisPaneli.SetActive(false);
        }
    }


}
