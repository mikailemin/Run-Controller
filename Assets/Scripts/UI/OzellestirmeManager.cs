using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mikail;
using TMPro;
using UnityEngine.UI;


public class OzellestirmeManager : MonoBehaviour
{

    public TextMeshProUGUI puanText;
    public TextMeshProUGUI SapkaText;
    [Header("SAPKALAR")]
    public GameObject[] Sapkalar;
    public Button[] Sapkabutonlari;
    [Header("SOPALAR")]
    public GameObject[] Sopalar;
    [Header("MATERİAL")]
    public Material[] Materials;
   
    int SapkaIndex = -1;

    BellekYonetim bellekYonetim = new BellekYonetim();
    VeriYonetimi veriYonetimi = new VeriYonetimi();

    public List<ItemBilgileri> ItemBilgileri = new List<ItemBilgileri>();

    void Start()
    {
        bellekYonetim.VeriKaydet_int("AktifSapka", -1);

        if (bellekYonetim.VeriOku_I("AktifSapka")==-1)
        {
            foreach (var item in Sapkalar)
            {
                item.SetActive(false);
            }
            SapkaIndex = -1;
            SapkaText.text = "Şapka Yok";
        }
        else
        {
            SapkaIndex = bellekYonetim.VeriOku_I("AktifSapka");
            Sapkalar[SapkaIndex].SetActive(true);
        }

       // veriYonetimi.Save(ItemBilgileri);

        veriYonetimi.Load();
         ItemBilgileri = veriYonetimi.ListeyiAktar();
        
    }



  



    public void SapkaYonButonlari(string islem)
    {
        if (islem=="ileri")
        {
            if (SapkaIndex==-1)
            {
                SapkaIndex= 0;
                Sapkalar[SapkaIndex].SetActive(true);
                SapkaText.text= ItemBilgileri[SapkaIndex].ItemAd;

            }
            else
            {
                Sapkalar[SapkaIndex].SetActive(false);
                SapkaIndex++;
                Sapkalar[SapkaIndex].SetActive(true);
                SapkaText.text = ItemBilgileri[SapkaIndex].ItemAd;


            }

            //------------------------------------------------

            if (SapkaIndex==Sapkalar.Length-1)
            {
                Sapkabutonlari[1].interactable = false;
            }
            else
            {
                Sapkabutonlari[1].interactable = true;
            }

            if (SapkaIndex!=-1)
            {
                Sapkabutonlari[0].interactable=true;
            }


        }
        else
        {
            if (SapkaIndex!=-1)
            {
                Sapkalar[SapkaIndex].SetActive(false);
                SapkaIndex--;

                if (SapkaIndex!=-1)
                {
                    Sapkalar[SapkaIndex].SetActive(true);
                    Sapkabutonlari[0].interactable = true;
                    SapkaText.text = ItemBilgileri[SapkaIndex].ItemAd;
                }
                else
                {
                    Sapkabutonlari[0].interactable = false;
                    SapkaText.text = "Şapka Yok";
                }
            }
            else
            {
                Sapkabutonlari[0].interactable = false;
                SapkaText.text = "Şapka Yok";
            }
            //---------------------------------------------
            if (SapkaIndex!=Sapkalar.Length-1)
            {
                Sapkabutonlari[1].interactable = true;
            }

        }

    }





   
}
