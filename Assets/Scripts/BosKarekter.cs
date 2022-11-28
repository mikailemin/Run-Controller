using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BosKarekter : MonoBehaviour
{
    public NavMeshAgent navMesh;
    public Animator animator;
    public GameObject Target;


    public SkinnedMeshRenderer Renderer;
    public Material AtanacakOlanMateryal;
    bool temasvar;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AltKarekterler") || other.CompareTag("Player"))
        {

            if (gameObject.CompareTag("BosKarekter"))
            {
                MaterialDegistirveAnimasyonTetikle();

                temasvar = true;
                GetComponent<AudioSource>().Play();
            }
          
        }
        else if (other.CompareTag("igneliKutu"))
        {
            Vector3 yeniPos = new Vector3(transform.position.x, 0.23f, transform.position.z);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokolmaEfektiOlustur(yeniPos);

            gameObject.SetActive(false);

        }

        if (other.CompareTag("Enemy"))
        {
            Vector3 yeniPos = new Vector3(transform.position.x, 0.23f, transform.position.z);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokolmaEfektiOlustur(yeniPos, false);

            gameObject.SetActive(false);

        }


    }
    private void LateUpdate()
    {
        if (temasvar)
            navMesh.SetDestination(Target.transform.position);
    }
    void MaterialDegistirveAnimasyonTetikle()
    {
        Material[] mats = Renderer.materials;
        mats[0] = AtanacakOlanMateryal;
        Renderer.materials = mats;

        animator.SetBool("Saldir", true);


        gameObject.tag = "AltKarekterler";
        GameManager.AnlikKarekterSayisi++;

    }


}
