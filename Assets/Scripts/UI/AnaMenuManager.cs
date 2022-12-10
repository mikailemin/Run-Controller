using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using mikail;
using System;

public class AnaMenuManager : MonoBehaviour
{
    BellekYonetim bellekYonetim=new BellekYonetim();
    VeriYonetimi veriYonetimi=new VeriYonetimi();
    public GameObject cikisPaneli;
    public List<ItemBilgileri> ItemBilgileri = new List<ItemBilgileri>();
    void Start()
    {
        bellekYonetim.KontrolEtveTanimla();
       // veriYonetimi.IlkKurulumDosyaOlusturma(ItemBilgileri);  diğer tüm itemlar bitince aktifleştir.
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
