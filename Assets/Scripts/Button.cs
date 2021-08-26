using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject inimigo;
    public Transform spaws;
    public Text texto;
    private bool isPress = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && isPress == true)
        {
            Instantiate(inimigo, spaws.position, spaws.rotation);
        }
    }
    private void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            isPress = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player"){
            isPress = false;
        }
    }
}
