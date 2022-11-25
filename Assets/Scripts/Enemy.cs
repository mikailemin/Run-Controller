using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject saldiriHedefi;
    NavMeshAgent NavMesh;
    bool saldiriBasladimi;
    void Start()
    {
        NavMesh=GetComponent<NavMeshAgent>();
    }

    public void AnimasyonTetikle()
    {

        GetComponent<Animator>().SetBool("Saldir", true);
        saldiriBasladimi=true;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (saldiriBasladimi)
        NavMesh.SetDestination(saldiriHedefi.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AltKarekterler"))
        {
            Vector3 yeniPos = new Vector3(transform.position.x, 0.23f, transform.position.z);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokolmaEfektiOlustur(yeniPos,true);

            gameObject.SetActive(false);

        }
    }

}
