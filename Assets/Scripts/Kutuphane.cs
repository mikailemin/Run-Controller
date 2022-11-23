using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace mikail
{
    public class Kutuphane : MonoBehaviour
    {

        public static void Carpma(int gelenSayi, List<GameObject> Karekterler, Transform pozisyon,List<GameObject> OlusturmaEfektleri)
        {

            int DonguSayisi = (GameManager.AnlikKarekterSayisi * gelenSayi) - GameManager.AnlikKarekterSayisi;
            int sayi = 0;
            foreach (var item in Karekterler)
            {
                if (sayi < DonguSayisi)
                {
                    if (!item.activeInHierarchy)
                    {
                        foreach (var item2 in OlusturmaEfektleri)
                        {
                            if (!item2.activeInHierarchy)
                            {
                               
                                item2.SetActive(true);
                                item2.transform.position = pozisyon.position;
                                item2.GetComponent<ParticleSystem>().Play();
                                break;
                            }
                        }


                        item.transform.position = pozisyon.transform.position;
                        item.SetActive(true);

                        sayi++;

                    }

                }
                else
                {
                    sayi = 0;
                    break;
                }
            }

            GameManager.AnlikKarekterSayisi *= gelenSayi;


        }

        public static void Toplama(int gelenSayi, List<GameObject> Karekterler, Transform pozisyon, List<GameObject> OlusturmaEfektleri)
        {

            int sayi2 = 0;
            foreach (var item in Karekterler)
            {
                if (sayi2 < gelenSayi)
                {
                    if (!item.activeInHierarchy)
                    {
                        foreach (var item2 in OlusturmaEfektleri)
                        {
                            if (!item2.activeInHierarchy)
                            {

                                item2.SetActive(true);
                                item2.transform.position = pozisyon.position;
                                item2.GetComponent<ParticleSystem>().Play();
                                break;
                            }
                        }

                        item.transform.position = pozisyon.transform.position;
                        item.SetActive(true);

                        sayi2++;

                    }

                }
                else
                {
                    sayi2 = 0;
                    break;
                }
            }

            GameManager.AnlikKarekterSayisi += gelenSayi;




        }

        public static void Cikartma(int gelenSayi, List<GameObject> Karekterler,List<GameObject> YokOlmaEfekleri)
        {

            if (GameManager.AnlikKarekterSayisi < gelenSayi)
            {
                foreach (var item in Karekterler)
                {
                    foreach (var item2 in YokOlmaEfekleri)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            Vector3 yeniPos = new Vector3(item.transform.position.x, 0.23f, item.transform.position.z);
                            item2.SetActive(true);
                            item2.transform.position = yeniPos;
                            item2.GetComponent<ParticleSystem>().Play();
                            break;
                        }
                    }



                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManager.AnlikKarekterSayisi = 1;
            }
            else
            {
                int sayi3 = 0;
                foreach (var item in Karekterler)
                {
                    if (sayi3 < gelenSayi)
                    {
                        if (item.activeInHierarchy)
                        {
                            foreach (var item2 in YokOlmaEfekleri)
                            {
                                if (!item2.activeInHierarchy)
                                {
                                    Vector3 yeniPos = new Vector3(item.transform.position.x, 0.23f, item.transform.position.z);
                                    item2.SetActive(true);
                                    item2.transform.position = yeniPos;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    break;
                                }
                            }





                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            sayi3++;

                        }

                    }
                    else
                    {
                        sayi3 = 0;
                        break;
                    }
                }
            }



            GameManager.AnlikKarekterSayisi -= gelenSayi;



        }

        public static void Bolme(int gelenSayi, List<GameObject> Karekterler, List<GameObject> YokOlmaEfekleri)
        {

            if (GameManager.AnlikKarekterSayisi <= gelenSayi)
            {
                foreach (var item in Karekterler)
                {
                    foreach (var item2 in YokOlmaEfekleri)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            Vector3 yeniPos = new Vector3(item.transform.position.x, 0.23f, item.transform.position.z);
                            item2.SetActive(true);
                            item2.transform.position = yeniPos;
                            item2.GetComponent<ParticleSystem>().Play();
                            break;
                        }
                    }


                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManager.AnlikKarekterSayisi = 1;
            }
            else
            {
                int bolen = GameManager.AnlikKarekterSayisi / gelenSayi;
                int sayi4 = 0;
                foreach (var item in Karekterler)
                {
                    if (sayi4 < bolen)
                    {
                        if (item.activeInHierarchy)
                        {
                            foreach (var item2 in YokOlmaEfekleri)
                            {
                                if (!item2.activeInHierarchy)
                                {
                                    Vector3 yeniPos = new Vector3(item.transform.position.x, 0.23f, item.transform.position.z);
                                    item2.SetActive(true);
                                    item2.transform.position = yeniPos;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    break;
                                }
                            }


                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            sayi4++;

                        }

                    }
                    else
                    {
                        sayi4 = 0;
                        break;
                    }
                }
            }
            if (GameManager.AnlikKarekterSayisi % gelenSayi == 0)
            {
                GameManager.AnlikKarekterSayisi /= gelenSayi;
            }
            else if (GameManager.AnlikKarekterSayisi % gelenSayi == 1)
            {
                GameManager.AnlikKarekterSayisi /= gelenSayi;
                GameManager.AnlikKarekterSayisi++;
            }
            else
            {
                GameManager.AnlikKarekterSayisi /= gelenSayi;
                GameManager.AnlikKarekterSayisi += 2;
            }




        }



    }



}
