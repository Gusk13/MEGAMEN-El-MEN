using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megaman : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpforce;
    [SerializeField] BoxCollider2D shoes;
    Rigidbody2D cuerpo;
    Animator mianimador;
    public GameObject[] bullet;
    public bool shooting;
    private float tiempo_disparo;
    public float time;
    public GameObject point;
    public bool dash;
    public float dash_t;
    public float speed_dash;
    public float doublejumpspeed = 2.5f;
    private bool candoublejump;
    



    // Start is called before the first frame update
    void Start()
    {
        mianimador = GetComponent<Animator>();
        mianimador.SetBool("Moviendo", false);
        cuerpo = GetComponent<Rigidbody2D>();
        
        dash = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        correr();
        saltar();
        caer();
        disparar();
        dash_skill();



    }
    void saltar()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            mianimador.SetBool("Cayendo", false);

            if (Entierra())
            {

                candoublejump = true;
                //cuerpo.AddForce(new Vector2(0, jumpforce));
                cuerpo.velocity = new Vector2(cuerpo.velocity.x, jumpforce);
                mianimador.SetTrigger("Saltando");

            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (candoublejump)
                    {

                        cuerpo.velocity = new Vector2(cuerpo.velocity.x, jumpforce);
                        candoublejump = false;
                    }
                }
            }

        }

    }
    void caer()
    {
        if (cuerpo.velocity.y < 0)
        {
            mianimador.SetBool("Cayendo", true);

        }
        else if (cuerpo.velocity.y > 0)
        {
            mianimador.SetBool("Cayendo", false);

        }

    }
    bool Entierra()
    {
        return shoes.IsTouchingLayers(LayerMask.GetMask("Suelo"));


    }


    void disparar()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            tiempo_disparo = 0.01f;
            GameObject obj = Instantiate(bullet[0], point.transform.position, transform.rotation) as GameObject;
            if (!shooting)
            {
                shooting = true;
            }
        }
        if (shooting)
        {
            tiempo_disparo += 1 * Time.deltaTime;
            mianimador.SetLayerWeight(0, 0);
            mianimador.SetLayerWeight(1, 1);
        }
        else
        {
            mianimador.SetLayerWeight(0, 1);
            mianimador.SetLayerWeight(1, 0);
        }
        if (tiempo_disparo >= time)
        {
            shooting = false;
            tiempo_disparo = 0;

        }

    }



    void correr()
    {
        if (Input.GetKey(KeyCode.D) && !dash)
        {
            mianimador.SetBool("Moviendo", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            mianimador.SetBool("Moviendo", false);
        }
        if (Input.GetKey(KeyCode.A) && !dash)
        {
            mianimador.SetBool("Moviendo", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

    }
    void dash_skill()
    {
        if (Entierra())

            if (Input.GetKey(KeyCode.X))
            {
                dash_t += 1 * Time.deltaTime;
                if (dash_t < 0.35f)
                {
                    dash = true;
                    mianimador.SetBool("dash", true);
                    transform.Translate(Vector2.right * speed_dash * Time.deltaTime);

                }
                else
                {
                    dash = false;
                    mianimador.SetBool("dash", false);
                }
            }
            else
            {
                dash = false;
                mianimador.SetBool("dash", false);
                dash_t = 0;

            }

    }
}
