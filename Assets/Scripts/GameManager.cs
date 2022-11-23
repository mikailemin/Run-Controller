using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mikail;

public class GameManager : MonoBehaviour
{



    public GameObject varisNoktasi;
    public static int AnlikKarekterSayisi = 1;


    public List<GameObject> Karekterler;
    public List<GameObject> OlusmaEfektleri;
    public List<GameObject> YokOlmaEfektleri;

    void Start()
    {

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

    public void AdamYonetim(string islemTuru, int gelenSayi, Transform pozisyon)
    {
        switch (islemTuru)
        {
            case "Carpma":
                Kutuphane.Carpma(gelenSayi, Karekterler, pozisyon,OlusmaEfektleri);
                break;

            case "Toplama":
                Kutuphane.Toplama(gelenSayi, Karekterler, pozisyon,OlusmaEfektleri);
                break;
            case "Cikartma":

                Kutuphane.Cikartma(gelenSayi, Karekterler,YokOlmaEfektleri);

                break;
            case "Bolme":

                Kutuphane.Bolme(gelenSayi, Karekterler,YokOlmaEfektleri);

                break;
        }
    }

    public void YokolmaEfektiOlustur(Vector3 pozisyon)
    {
        foreach (var item in YokOlmaEfektleri)
        {
            if (!item.activeInHierarchy)
            {

                item.SetActive(true);
                item.transform.position = pozisyon;
                item.GetComponent<ParticleSystem>().Play();
                GameManager.AnlikKarekterSayisi--;
                break;



            }
        }

    }
}
