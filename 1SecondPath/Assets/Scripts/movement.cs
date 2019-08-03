using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speedx;
    public float jumpforce;
    public float speedmaxx;

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


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
        }
    }
}
