using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public void IniciarJogo() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
    public void Sair(){
        Application.Quit();
    }

    public void voltarMenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
