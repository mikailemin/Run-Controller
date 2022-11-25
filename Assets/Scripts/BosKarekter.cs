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
            MaterialDegistirveAnimasyonTetikle();

            temasvar = true;
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
        Renderer.materials=mats;

        animator.SetBool("Saldir", true);
    }


}
