using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rangotorr : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            transform.GetComponentInParent<Enemy>().Atacando();
        }
    }
}
