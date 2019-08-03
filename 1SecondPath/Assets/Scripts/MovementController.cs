using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody rb;
    float velocity = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(0f, 0f,0f);
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (rb.velocity.y < 1.5)
            {
                rb.velocity += new Vector3(0f, velocity * Time.timeScale, 0f);
            }
           
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (rb.velocity.y > -1.5)
            {
                rb.velocity -= new Vector3(0f, velocity * Time.timeScale, 0f);
            }

        }

        if (Input.GetKey(KeyCode.A))
        {
            if (rb.velocity.x > -1.5)
            {
                rb.velocity -= new Vector3(velocity * Time.timeScale, 0f, 0f);
            }

        }

        if (Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.x < 1.5)
            {
                rb.velocity += new Vector3(velocity * Time.timeScale, 0f, 0f);
            }

        }
    }
}
