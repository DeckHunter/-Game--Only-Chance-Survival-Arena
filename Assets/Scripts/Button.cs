using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject inimigo;
    public Transform[] spaws;
    public Text texto;
    private bool isPress = false;
    public GameObject aviso;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && isPress == true)
        {
            foreach (var s in spaws)
            {
                Instantiate(inimigo, s.position, s.rotation);
            }
        }
    }
    private void OnTriggerEnter(Collider other){
        aviso.SetActive(true);
        if (other.tag == "Player"){
            isPress = true;
        }
 
    }
    private void OnTriggerExit(Collider other)
    {
        aviso.SetActive(false);
        if (other.tag == "Player"){
            isPress = false;
        }
    }
}
