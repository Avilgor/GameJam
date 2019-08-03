using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pmovementx : MonoBehaviour
{
    public float pmaxx;
    public float pminx;
    public float pspeedx;
    bool pright;
    Rigidbody2D rbp;

    // Start is called before the first frame update
    void Start()
    {
        rbp = GetComponent<Rigidbody2D>();
        pright = true;
        rbp.velocity = new Vector2(0.1f,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= pmaxx && pright)
        {
            rbp.velocity = new Vector2(-pspeedx, 0);
            pright = false;
            print("right");
            
        }

        else if (transform.position.x <= pminx && !pright)
        {
            rbp.velocity = new Vector2(pspeedx, 0);
            pright = true;
        }

        /*if (transform.position.y >= pmaxy)
        {
            rbp.velocity = new Vector2(0, -pspeedy);
        }

        else if (transform.position.y <= pminy)
        {
            rbp.velocity = new Vector2(0, pspeedy);
        }
        */


    }
}
