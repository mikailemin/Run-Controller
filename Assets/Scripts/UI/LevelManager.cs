using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using mikail;

public class LevelManager : MonoBehaviour
{

    public Button[] Butonlar;
    public int Level;
    public Sprite kilitliButon;

    BellekYonetim bellekYonetim = new BellekYonetim();
    void Start()
    {

  


        int mevcutLevel = bellekYonetim.VeriOku_I("SonLevel") - 4;
        int index = 1;
        for (int i = 0; i < Butonlar.Length; i++)
        {
            if (i + 1 <= mevcutLevel)
            {
                Butonlar[i].GetComponentInChildren<TextMeshProUGUI>().text = index.ToString();
                int sahneIndex = index + 4;
                Butonlar[i].onClick.AddListener(delegate { SahneYukle(sahneIndex); });
                
            }
            else
            {
                Butonlar[i].GetComponent<Image>().sprite = kilitliButon;
                //  Butonlar[i].interactable=false;  
                Butonlar[i].enabled = false;
            }
            index++;
        }
    }
    public void SahneYukle(int index)
    {
       
        SceneManager.LoadScene(index);
    }


    public void GeriDon()
    {
        SceneManager.LoadScene(0);
    }
}
