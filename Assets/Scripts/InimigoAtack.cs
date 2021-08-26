using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InimigoAtack : MonoBehaviour
{

    private Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            if (player.getLifeAtual() > 0)
            {
                if (player.GetArmor() > 0)
                {
                    player.tomarDanoArmadura(10);
                    Debug.Log("Player Tomou " + player.getLifeAtual() + " De Dano");
                }
                else {
                    player.tomarDano(10);
                }
            }
        }
    }
}
