using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efecto : MonoBehaviour
{
    [SerializeField] private float tiempoefec;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, tiempoefec);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
