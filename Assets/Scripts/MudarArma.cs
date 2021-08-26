using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudarArma : MonoBehaviour
{
    [Space]
    [Header("Pistolas")]
    public GameObject Pistola_Dir;
    public GameObject Pistola_Esq;

    [Space]
    [Header("ShotGun")]
    public GameObject ShotGun_Dir;
    public GameObject ShotGun_Esq;

    [Space]
    [Header("Machine Gun")]
    public GameObject Machine_Gun_Dir;
    public GameObject Machine_Gun_Esq;

    private Player player;
    private void Start()
    {
        Pistola_Dir.SetActive(true);
        Pistola_Esq.SetActive(true);

        Machine_Gun_Dir.SetActive(false);
        Machine_Gun_Esq.SetActive(false);

        ShotGun_Dir.SetActive(false);
        ShotGun_Esq.SetActive(false);

        player = GetComponent<Player>();
    }

    void Update()
    {
        if (player.getLifeAtual() > 0 && player.GetplayerInShop() == false)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Pistola_Dir.SetActive(true);
                Pistola_Esq.SetActive(true);

                Machine_Gun_Dir.SetActive(false);
                Machine_Gun_Esq.SetActive(false);

                ShotGun_Dir.SetActive(false);
                ShotGun_Esq.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Pistola_Dir.SetActive(false);
                Pistola_Esq.SetActive(false);

                Machine_Gun_Dir.SetActive(true);
                Machine_Gun_Esq.SetActive(true);

                ShotGun_Dir.SetActive(false);
                ShotGun_Esq.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Pistola_Dir.SetActive(false);
                Pistola_Esq.SetActive(false);

                Machine_Gun_Dir.SetActive(false);
                Machine_Gun_Esq.SetActive(false);

                ShotGun_Dir.SetActive(true);
                ShotGun_Esq.SetActive(true);
            }
        }
    }
}
