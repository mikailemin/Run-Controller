using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mikail;
using System;

public class GameManager : MonoBehaviour
{



    public GameObject varisNoktasi;
    public static int AnlikKarekterSayisi = 1;


    public List<GameObject> Karekterler;
    public List<GameObject> OlusmaEfektleri;
    public List<GameObject> YokOlmaEfektleri;

    [Header("LEVEL VERİLERİ")]
    public List<GameObject> Enemies;
    public int KacDusmanOlsun;
    public GameObject AnaKarekter;
    public bool oyunBittMi;
    public bool sonaGeldikMi;

    void Start()
    {
        DusmanlariOlustur();
    }

    public void DusmanlariOlustur()
    {
        for (int i = 0; i < KacDusmanOlsun; i++)
        {
            Enemies[i].SetActive(true);
        }
    }
    public void DusmanlariTetikle()
    {

        foreach (var item in Enemies)
        {
            if (item.activeInHierarchy)
            {
                item.GetComponent<Enemy>().AnimasyonTetikle();
            }
        }
        sonaGeldikMi = true;
        SavasDurumu();

    }


    // Update is called once per frame
    void Update()
    {
        #region
        /*  if (Input.GetKeyDown(KeyCode.A))
          {
              foreach (var item in Karekterler)
              {
                  if (!item.activeInHierarchy)
                  {
                      item.transform.position=dogmaNoktasi.transform.position;
                      item.SetActive(true);
                      AnlikKarekterSayisi++;
                      break;
                  }

              }
          }*/
        #endregion



    }


    void SavasDurumu()
    {

        if (sonaGeldikMi)
        {

            if (AnlikKarekterSayisi == 1 || KacDusmanOlsun == 0)
            {
                oyunBittMi = true;
                foreach (var item in Enemies)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Saldir", false);
                    }
                }

                foreach (var item in Karekterler)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Saldir", false);
                    }
                }
                AnaKarekter.GetComponent<Animator>().SetBool("Saldir", false);


                if (AnlikKarekterSayisi < KacDusmanOlsun || AnlikKarekterSayisi == KacDusmanOlsun)
                {
                    Debug.Log("Kaybetttin");
                }
                else
                {
                    Debug.Log("Kazandın");
                }
            }
        }
    }


    public void AdamYonetim(string islemTuru, int gelenSayi, Transform pozisyon)
    {
        switch (islemTuru)
        {
            case "Carpma":
                Kutuphane.Carpma(gelenSayi, Karekterler, pozisyon, OlusmaEfektleri);
                break;

            case "Toplama":
                Kutuphane.Toplama(gelenSayi, Karekterler, pozisyon, OlusmaEfektleri);
                break;
            case "Cikartma":

                Kutuphane.Cikartma(gelenSayi, Karekterler, YokOlmaEfektleri);

                break;
            case "Bolme":

                Kutuphane.Bolme(gelenSayi, Karekterler, YokOlmaEfektleri);

                break;
        }
    }

    public void YokolmaEfektiOlustur(Vector3 pozisyon, bool durum = false)
    {
        foreach (var item in YokOlmaEfektleri)
        {
            if (!item.activeInHierarchy)
            {

                item.SetActive(true);
                item.transform.position = pozisyon;
                item.GetComponent<ParticleSystem>().Play();
                if (!durum)
                {
                    GameManager.AnlikKarekterSayisi--;
                }
                else
                {
                    KacDusmanOlsun--;
                }

                break;



            }
        }
        if (!oyunBittMi)
        {
            SavasDurumu();
        }


    }
}
