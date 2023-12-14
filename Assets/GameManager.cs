using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void IrAJuego()
    {
       SceneManager.LoadScene("SampleScene");
    }

    public void Die()
    {
        SceneManager.LoadScene("End");
    }

    public void Win()
    {
        SceneManager.LoadScene("Win");
    }

    public void Comandos()
    {
        SceneManager.LoadScene("Comandos");
    }

    public void StartG()
    {
        SceneManager.LoadScene("Start");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}

