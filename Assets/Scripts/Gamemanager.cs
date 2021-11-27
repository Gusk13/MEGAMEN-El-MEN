using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public GameObject Reiniciar;
    public Image GameOver;
    [SerializeField] int numEnemies;
    [SerializeField] Saludmega Megaman;
    public Text contadorenemitxt;
    void Start()
    {
        GameOver.enabled = false;
        Reiniciar.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        contadorenemitxt.text = "0" + numEnemies;
    }
    public void ReducirNumEnemigos()
    {
        numEnemies = numEnemies - 1;
        if (numEnemies < 1)
        {
            numEnemies--;
            GameOver.enabled = true;
            Reiniciar.gameObject.SetActive(true);
            Time.timeScale = 0;
           
        }
   
    }
}
