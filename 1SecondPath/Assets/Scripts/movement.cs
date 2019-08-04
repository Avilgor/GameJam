using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public float speedx;
    public float jumpforce;
    public float speedmaxx;
    public LayerMask groundLayer;
    public LayerMask playerLayer;
    Vector2 rayposition;
    Vector2 raydirection;
    public float raydistance;
    bool grounded;
    bool jump;
    bool moveleft;
    bool moveright;
    bool stop;
    bool ascensor;
    float timer;
    public ParticleSystem jumpEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        ascensor = false;
        Globals.death = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKey(KeyCode.D) && rb.velocity.x <= speedmaxx && timer > 1 )
        {
            moveleft = false;
            moveright = true;
            stop = false;
        }

        else if (Input.GetKey(KeyCode.A) && rb.velocity.x >= -speedmaxx && timer > 1)
        {
            moveright = false;
            moveleft = true;
            stop = false;
        }

        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            stop = true;
            moveright = false;
            moveleft = false;
        }


        if (Input.GetKeyDown(KeyCode.W) && grounded && !jump|| Input.GetKeyDown(KeyCode.Space) && grounded && !jump && timer > 1)
        {
            jump = true;
        }

        else if (Input.GetKeyDown(KeyCode.S) && grounded && timer > 1)
        {
            StartCoroutine("Drop");
        }


        //aquí va lo de Raycast para el CheckGround

        rayposition = transform.position + new Vector3 (0, 0.1f, 0);
        raydirection = -transform.up;



        //Para el movimiento en plataformas movibles

     



    }

    IEnumerator Drop()
    {
        bc.enabled = false;
        yield return new WaitForSeconds(0.4f);
        bc.enabled = true;
    }

    private void FixedUpdate()
    {
        Physics2D.IgnoreLayerCollision(8, 9, rb.velocity.y > 0);

        if (jump)
        {
            jumpEffect.Play();
            rb.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
            jump = false;
        }

        if (moveright)

        {
            rb.velocity += new Vector2(speedx, 0f);
            moveright = false;
        }

        else if (moveleft)
        {
            rb.velocity += new Vector2(-speedx, 0f);
            moveleft = false;
        }

        else if (stop && grounded)
        {
            rb.velocity -= new Vector2 (0.12f * rb.velocity.x, 0);
        }

        else if (stop && !grounded)
        {
            rb.velocity -= new Vector2(0.04f * rb.velocity.x, 0);
        }


        Debug.DrawRay(rayposition, raydirection * raydistance, Color.green);
        Debug.DrawRay(rayposition + new Vector2(0.17f, 0), raydirection * raydistance, Color.red);
        Debug.DrawRay(rayposition + new Vector2(-0.17f, 0), raydirection * raydistance, Color.cyan);
        RaycastHit2D hitsuelo = Physics2D.Raycast(rayposition, raydirection, raydistance, groundLayer);
        RaycastHit2D hitsuelo1 = Physics2D.Raycast(rayposition + new Vector2(0.17f, 0), raydirection, raydistance, groundLayer);
        RaycastHit2D hitsuelo2 = Physics2D.Raycast(rayposition + new Vector2(-0.17f, 0), raydirection, raydistance, groundLayer);

        if (hitsuelo.collider != null && rb.velocity.y > -1 || hitsuelo1.collider != null && rb.velocity.y > -1 || hitsuelo2.collider != null && rb.velocity.y > -1 )
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }





}
