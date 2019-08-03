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

    // Start is called before the first frame update
    void Start()
    {
        rbp = GetComponent<Rigidbody2D>();
        pup = false;
        rbp.velocity = new Vector2(0, -0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (transform.position.x >= pmaxx && pright)
        {
            rbp.velocity = new Vector2(-pspeedx, 0);
            pright = false;
            print("right");
        }

        else if (transform.position.x <= pminx && !pright)
        {
            rbp.velocity = new Vector2(pspeedx, 0);
            pright = true;
        } */

        if (transform.position.y >= pmaxy && pup)
        {
            rbp.velocity = new Vector2(0, -pspeedy);
            pup = false;

        }

        else if (transform.position.y <= pminy && !pup)
        {
            rbp.velocity = new Vector2(0, pspeedy);
            pup = true;
        }


        

    }
}
