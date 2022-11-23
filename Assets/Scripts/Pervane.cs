using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pervane : MonoBehaviour
{

    public Animator animator;

    public BoxCollider ruzgar;


    public void AnimasyonDurum(string durum)
    {

        if (durum=="true")
        {
            animator.SetBool("calistir", true);
            ruzgar.enabled = true;

        }
        else
        {
            animator.SetBool("calistir", false);
            StartCoroutine(AnimasyonTetikle());
            ruzgar.enabled = false;
        }
      


    }

    IEnumerator AnimasyonTetikle()    
    {

        yield return new WaitForSeconds(2f);
        AnimasyonDurum("true");
    
    }



}
