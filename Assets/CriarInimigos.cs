using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriarInimigos : MonoBehaviour
{

    public GameObject[] lista_Pos;
    public GameObject inimigo;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") {
            foreach (var poss in lista_Pos)
            {
                Instantiate(inimigo, poss.transform.position, poss.transform.rotation);
            }
            Destroy(gameObject);
        }
    }

}
