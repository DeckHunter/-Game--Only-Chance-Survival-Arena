using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private float life_boss;
    public GameObject Drop_Boss_Moeda;
    public GameObject Drop_Boss_Chave;

    public Slider life_bar;
    public GameObject life_bar_;
   
    public float GetLife()
    {
        return life_boss;
    }
    public void LevarDano(float dano)
    {
        life_boss -= dano/25;
        Debug.Log("Vida Do Inimigo : " + life_boss);
    }
    void Update()
    {
        life_bar.value = life_boss;
        Debug.Log("Vida Do Boss : " + life_boss);

        if (life_boss > 0)
        {
            life_bar_.SetActive(true);
        }

        if (GetLife() <= 0f)
        {
            life_bar_.SetActive(false);
            Debug.Log("Boss Morre");
            Morrer();
        }
    }
    public void Morrer()
    {
        Destroy(gameObject);
        DropItens();
    }

    public void DropItens()
    {

        for (int i = 0; i < 100; i++)
        {
            Instantiate(Drop_Boss_Moeda, transform.position, transform.rotation);
        }
        Instantiate(Drop_Boss_Chave, transform.position, transform.rotation);

    }
}
