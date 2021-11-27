using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemytwo : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            transform.GetComponentInParent<Enemigo3>().Atacando();
        }
    }

   




}
