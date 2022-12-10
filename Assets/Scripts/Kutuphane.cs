using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace mikail
{
    public class Kutuphane
    {

        public void Carpma(int gelenSayi, List<GameObject> Karekterler, Transform pozisyon, List<GameObject> OlusturmaEfektleri)
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
                                item2.GetComponent<AudioSource>().Play();
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

        public void Toplama(int gelenSayi, List<GameObject> Karekterler, Transform pozisyon, List<GameObject> OlusturmaEfektleri)
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
                                item2.GetComponent<AudioSource>().Play();

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

        public void Cikartma(int gelenSayi, List<GameObject> Karekterler, List<GameObject> YokOlmaEfekleri)
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
                            item2.GetComponent<AudioSource>().Play();
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
                                    item2.GetComponent<AudioSource>().Play();
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

        public void Bolme(int gelenSayi, List<GameObject> Karekterler, List<GameObject> YokOlmaEfekleri)
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
                            item2.GetComponent<AudioSource>().Play();
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
                                    item2.GetComponent<AudioSource>().Play();
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


    public class BellekYonetim
    {
        public void VeriKaydet_string(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
            PlayerPrefs.Save();
        }

        public void VeriKaydet_int(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.Save();
        }

        public void VeriKaydet_float(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
            PlayerPrefs.Save();
        }


        public string VeriOku_S(string key)
        {

            return PlayerPrefs.GetString(key);
        }

        public int VeriOku_I(string key)
        {

            return PlayerPrefs.GetInt(key);
        }
        public float VeriOku_F(string key)
        {

            return PlayerPrefs.GetFloat(key);
        }


        public void KontrolEtveTanimla()
        {
            if (!PlayerPrefs.HasKey("SonLevel"))
            {
                PlayerPrefs.SetInt("SonLevel", 5);
                PlayerPrefs.SetInt("Puan", 0);
            }

        }




    }


    public class Verilerimiz
    {
        public static List<ItemBilgileri> ItemBilgileri = new List<ItemBilgileri>();
    }

    [Serializable]
    public class ItemBilgileri
    {
        public int GrupIndex;
        public int ItemIndex;
        public string ItemAd;
        public int Puan;
        public bool SatinAlmaDurumu;
    }
    public class VeriYonetimi
    {
        public void Save(List<ItemBilgileri> ItemBilgileri)
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.persistentDataPath + "/ItemVerileri.gd");
            bf.Serialize(file, ItemBilgileri);
            file.Close();


        }

        List<ItemBilgileri> ItemIcListe;
        public void Load()
        {
            if (File.Exists(Application.persistentDataPath + "/ItemVerileri.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/ItemVerileri.gd", FileMode.Open);
                ItemIcListe = (List<ItemBilgileri>)bf.Deserialize(file);
                file.Close();

            }
        }

        public List<ItemBilgileri> ListeyiAktar()
        {
            return ItemIcListe;

        }

        public void IlkKurulumDosyaOlusturma(List<ItemBilgileri> ItemBilgileri)
        {

            if (!File.Exists(Application.persistentDataPath + "/ItemVerileri.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Create(Application.persistentDataPath + "/ItemVerileri.gd");
                bf.Serialize(file, ItemBilgileri);
                file.Close();
            }

        }


    }


}

