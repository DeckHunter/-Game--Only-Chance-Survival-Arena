using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField]
    private float life_Inimigo;
    public GameObject Drop_Inimigo;

    private void Start()
    {
        life_Inimigo = 30f;
        Debug.Log("Vida Do Inimigo : " + life_Inimigo);

    }
    public float GetLife(){
        return life_Inimigo;
    }
    public void LevarDano(float dano){
        life_Inimigo -= dano;
        Debug.Log("Vida Do Inimigo : " + life_Inimigo);
    }
    void Update()
    {
        if (GetLife() <= 0f) {
            Debug.Log("Inimigo Morre");
            Morrer();
        }   
    }
    public void Morrer( ){
        Destroy(gameObject);
        DropItens();
    }

    public void DropItens(){
        System.Random rnd = new System.Random();
        int num = rnd.Next(1, 15);
        Debug.Log("Numero Gerado : " + num);

        for (int i = 0; i < num; i++)
        {
            Instantiate(Drop_Inimigo, transform.position, transform.rotation);
        }

    }
}
