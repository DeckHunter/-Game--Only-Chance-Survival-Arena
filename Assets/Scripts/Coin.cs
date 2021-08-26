using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject moeda_pai;
    public void Coletar(){
        Debug.Log("Moeda Coletada");
        Destroy(gameObject);
        Destroy(moeda_pai);
    }
}
