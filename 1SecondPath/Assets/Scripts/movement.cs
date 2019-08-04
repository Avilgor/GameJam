using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public Rigidbody2D rb;
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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ascensor = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D) && rb.velocity.x <= speedmaxx)
        {
            moveleft = false;
            moveright = true;
            stop = false;
        }

        else if (Input.GetKey(KeyCode.A) && rb.velocity.x >= -speedmaxx)
        {
            moveright = false;
            moveleft = true;
            stop = false;
        }

        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            print("stop");
            stop = true;
            moveright = false;
            moveleft = false;
        }


        if (Input.GetKeyDown(KeyCode.W) && grounded || Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jump = true;
        }


        //aquí va lo de Raycast para el CheckGround

        rayposition = transform.position;
        raydirection = -transform.up;



        //Para el movimiento en plataformas movibles

     



    }



    private void FixedUpdate()
    {
        Physics2D.IgnoreLayerCollision(8, 9, rb.velocity.y > 0);

        if (jump)
        {
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
        RaycastHit2D hitsuelo = Physics2D.Raycast(rayposition, raydirection, raydistance, groundLayer);

        if (hitsuelo.collider != null)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }



}
