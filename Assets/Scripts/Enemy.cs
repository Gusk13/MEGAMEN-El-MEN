using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform playerpos;
    public GameObject point;
    [SerializeField] CircleCollider2D rango;
    public GameObject[] bullet;
    public float tiempodis;
    
    public float timeToshoot;
   


    // Start is called before the first frame update
    void Start()
    {
        playerpos = GameObject.Find("Player").transform;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        

        //Debug.Log(Vector2.Distance(transform.position, playerpos.transform.position));
    }
    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(transform.position, playerpos.transform.position);
    }
    public void Flip()
    {
        if (playerpos.transform.position.x > this.transform.position.x)
        {

            transform.rotation = Quaternion.Euler(0, 0, 0);
           
        }
        else
        {

            transform.rotation = Quaternion.Euler(0, 180, 0);
            
        }
    }
   
    public void Atacando()
    {

        tiempodis -= Time.deltaTime;
        if(tiempodis < 0)
        {
            GameObject obj = Instantiate(bullet[0], point.transform.position, transform.rotation) as GameObject;
            tiempodis = timeToshoot;
        }
          


    }
   
 

}
