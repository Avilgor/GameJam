using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pmovementy : MonoBehaviour
{

    public float pmaxy;
    public float pminy;
    public float pspeedy;
    bool pup;
    Rigidbody2D rbp;
    bool pmoveup;

    // Start is called before the first frame update
    void Start()
    {
        rbp = GetComponent<Rigidbody2D>();
        pup = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= pmaxy && pup)
        {
            pmoveup = false;
            pup = false;

        }

        else if (transform.position.y <= pminy && !pup)
        {
            pmoveup = true;
            pup = true;
        }
    }



    void FixedUpdate()
    { 
        if (pup)
        {
            rbp.MovePosition(transform.position + transform.up * Time.fixedDeltaTime);
        }

        if (!pup)
        {
            rbp.MovePosition(transform.position + -transform.up * Time.fixedDeltaTime);
        }
    }
}
