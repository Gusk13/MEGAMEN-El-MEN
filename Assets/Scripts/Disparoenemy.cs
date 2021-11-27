using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparoenemy : MonoBehaviour
{
    public float speed;
    [SerializeField] private float tiempobala;
    public bool baibala;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, tiempobala);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        

    }
    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.collider.CompareTag("player"))
        {

           

            if (!baibala)
            {
                baibala = true;
            }


        }
        if (baibala)
        {
            Destroy(gameObject);
            Debug.Log("puff");
        }
    }
}
