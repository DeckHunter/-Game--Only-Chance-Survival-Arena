using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vendedora : MonoBehaviour
{
    public bool isPress = false;
    public bool isOpen = false;
    public GameObject loja;
    public Player player;
    public FirstPersonCamera firstPerson;

    [Space]
    [Header("Pistolas")]
    public Gun_1 Pistola_Dir;
    public Gun_2 Pistola_Esq;

    [Space]
    [Header("ShotGun")]
    public Gun_1 ShotGun_Dir;
    public Gun_2 ShotGun_Esq;

    [Space]
    [Header("Machine Gun")]
    public Gun_1 Machine_Gun_Dir;
    public Gun_2 Machine_Gun_Esq;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && isPress == true && isOpen == false)
        {
            isOpen = true;
            Debug.Log("Abrir Loja");
            loja.SetActive(true);
            player.SetplayerInShop(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && isPress == true && isOpen == true)
        {
            Debug.Log("Fechou A Loja");
            FecharLoja();
            
        }

        if (Input.GetKeyDown(KeyCode.F1) && isPress == true && isOpen == true)
        {
            if (player.GetMoedas() >= 30) {
                Debug.Log("Comprou KitMedico");
                player.AddKitMedico();
                player.RemoveMoedas(30);
            }
        }

        if (Input.GetKeyDown(KeyCode.F2) && isPress == true && isOpen == true)
        {
            if (player.GetMoedas() >= 30)
            {
                if (player.GetArmor() < 100){
                    player.setArmor();
                    player.RemoveMoedas(30);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && isPress == true && isOpen == true)
        {
            if (player.GetMoedas() >= 10)
            {
                Debug.Log("Comprou Bala De 12 Esquerda");
                ShotGun_Esq.AddMunicao(8);
                player.RemoveMoedas(10);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && isPress == true && isOpen == true)
        {
            if (player.GetMoedas() >= 10)
            {
                Debug.Log("Comprou Bala De 12 Direita");
                ShotGun_Dir.AddMunicao(8);
                player.RemoveMoedas(10);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && isPress == true && isOpen == true)
        {
            if (player.GetMoedas() >= 10)
            {
                Debug.Log("Comprou Bala De Metralhadora Esquerda");
                Machine_Gun_Esq.AddMunicao(30);
                player.RemoveMoedas(10);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && isPress == true && isOpen == true)
        {
            if (player.GetMoedas() >= 10)
            {
                Debug.Log("Comprou Bala De Metralhadora Direita");
                Machine_Gun_Dir.AddMunicao(30);
                player.RemoveMoedas(10);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && isPress == true && isOpen == true)
        {
            if (player.GetMoedas() >= 5)
            {
                Debug.Log("Comprou Bala De Pistola Esquerda");
                Pistola_Esq.AddMunicao(10);
                player.RemoveMoedas(5);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha6) && isPress == true && isOpen == true)
        {
            if (player.GetMoedas() >= 5)
            {
                Debug.Log("Comprou Bala De Pistola Direita");
                Pistola_Dir.AddMunicao(10);
                player.RemoveMoedas(5);
            }
        }

        if (isOpen == true) {

            player.StopPlayer();
            firstPerson.StopCam();
            player.SetplayerInShop(true);
        }
        else {
            player.StartPlayer();
            firstPerson.StartCam();
            player.SetplayerInShop(false);
        }
    }

    public void FecharLoja() {
        Debug.Log("Fechar Loja Precionado");
        loja.SetActive(false);
        isOpen = false;
        player.SetplayerInShop(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isPress = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPress = false;

        }
    }
}
