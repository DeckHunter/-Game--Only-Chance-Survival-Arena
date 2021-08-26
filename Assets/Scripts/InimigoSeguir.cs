using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoSeguir : MonoBehaviour
{
    private NavMeshAgent inimgo;
    private Transform ponto;
    //private Animation correr;
    // Start is called before the first frame update
    void Start()
    {
        inimgo = GetComponent<NavMeshAgent>();
        ponto = GameObject.Find("Player").transform;
        //correr = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        inimgo.SetDestination(ponto.position);
        //.Play();
    }
}
