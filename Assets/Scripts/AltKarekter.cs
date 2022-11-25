using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AltKarekter : MonoBehaviour
{
    GameObject target;
    NavMeshAgent navMesh;
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().varisNoktasi;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        navMesh.SetDestination(target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("igneliKutu"))
        {
           Vector3 yeniPos=new Vector3(transform.position.x,0.23f,transform.position.z);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokolmaEfektiOlustur(yeniPos);
           
            gameObject.SetActive(false);
            
        }
        if (other.CompareTag("Enemy"))
        {
            Vector3 yeniPos = new Vector3(transform.position.x, 0.23f, transform.position.z);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokolmaEfektiOlustur(yeniPos,false);

            gameObject.SetActive(false);

        }
    }
}
