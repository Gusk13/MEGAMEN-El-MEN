using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Saludabeja : MonoBehaviour
{
    [SerializeField] int numDisparos;
    [SerializeField] GameObject destrucioon;
    [SerializeField] private float tiempodes;
    [SerializeField] Gamemanager gm;
    Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("destruc", false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        ReducirVida();
        if (numDisparos < 1)
        {
            if (col.collider.CompareTag("bala"))
            {

                anim.SetBool("destruc", true);
                Debug.Log("cuchíplan");
                GetComponent<CircleCollider2D>().enabled = false;
                GetComponent<Enemy>().enabled = false;
                gm.ReducirNumEnemigos();
                Instantiate(destrucioon, transform.position, Quaternion.identity);
                Destroy(gameObject, tiempodes);
            }
        }




    }
    void ReducirVida()
    {

        numDisparos = numDisparos - 1;
    }
}
   
