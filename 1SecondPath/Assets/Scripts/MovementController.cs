using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    SpriteRenderer renderer;
    float velocity = 2f;
    private bool move;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        move = false;
        StartCoroutine(WaitMove(2f));
    }


    void Update()
    {
        if (move)
        {
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                rb.velocity = new Vector3(0f, 0f, 0f);
            }

            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector3(0f, velocity * Time.timeScale, 0f);
                anim.SetBool("Walk", false);
            }

            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector3(0f, -velocity * Time.timeScale, 0f);
                anim.SetBool("Walk", false);
            }

            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector3(-velocity * Time.timeScale, 0f, 0f);
                anim.SetBool("Walk", true);
                renderer.flipX = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector3(velocity * Time.timeScale, 0f, 0f);
                anim.SetBool("Walk",true);
                renderer.flipX = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            
        }       
    }

    IEnumerator WaitMove(float time)
    {
        yield return new WaitForSeconds(time);
        move = true;
    }
}
