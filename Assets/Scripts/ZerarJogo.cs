using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZerarJogo : MonoBehaviour
{
    private Player player;
    public GameObject Aviso;
    void Start()
    {
        player = FindObjectOfType<Player>();  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"){
            if (player.GetChave_1() == false || player.GetChave_2() == false || player.GetChave_3() == false)
            {
                Aviso.SetActive(true);
            }
            else {
                player.VencerOJogo();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Aviso.SetActive(false);
        }
    }
}
