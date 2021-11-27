using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField] private float tiempobala;
    Animator miani;
    public float speed;
    public bool baibala;
    

    void Start()
    {

       miani = GetComponent<Animator>();
       miani.SetBool("Desbala", false);
    }
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.collider.CompareTag("Plataform"))
        {
            
            miani.SetBool("Desbala", true);
            
            if(!baibala)
            {
                baibala = true;
            }


        }

        if (col.collider.CompareTag("enemy"))
        {

            miani.SetBool("Desbala", true);

            if (!baibala)
            {
                baibala = true;
            }


        }
        if (baibala)
        {
            Destroy(gameObject, tiempobala);
            Debug.Log("puff");
        }
    }

    
   
        
}
