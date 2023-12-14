using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public GameManager GameManager;
    public int counter = 1;
    public TextMeshProUGUI texto;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //
            if (counter == 2)
            {
                GameManager.Win();
            }
            else
            {
                counter++;
                Debug.Log("CONTACTO" + counter);
                texto.text = counter.ToString();
            }
            
        }
    }
}
