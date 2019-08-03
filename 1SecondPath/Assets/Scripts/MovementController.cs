using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    SpriteRenderer renderer;
    float velocity = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
            //animations.Stop("RatWalk");
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(0f, velocity * Time.timeScale, 0f);
            //animations.Stop("RatWalk");
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(0f, -velocity * Time.timeScale, 0f);
            //animations.Stop("RatWalk");
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-velocity * Time.timeScale, 0f, 0f);
            //animations.Play("RatWalk");
            renderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(velocity * Time.timeScale, 0f, 0f);
            //animations.Play("RatWalk");
            renderer.flipX = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            
        }       
    }
}
