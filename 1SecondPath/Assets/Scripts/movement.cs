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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D) && rb.velocity.x < speedmaxx)
        {
            rb.velocity += new Vector2 (speedx, 0f);
        }

        else if (Input.GetKey(KeyCode.A) && rb.velocity.x > -speedmaxx)
        {
            rb.velocity += new Vector2(-speedx, 0f);
        }


        if (Input.GetKeyDown(KeyCode.W) && grounded || Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
        }


        //aquí va lo de Raycast para el CheckGround

        rayposition = transform.position;
        raydirection = -transform.up;


        Debug.DrawRay(rayposition, raydirection * raydistance, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(rayposition, raydirection, raydistance, groundLayer);
        if (hit.collider != null)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        //Para el movimiento en plataformas movibles

     



    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "platform")
        {
            transform.parent = other.transform;
        }

    }
    /*
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("platform"))
        {
            player.transform.parent = null;
        }
    }*/

    private void FixedUpdate()
    {
        Physics2D.IgnoreLayerCollision(8, 9, rb.velocity.y > 0);
    }
}
