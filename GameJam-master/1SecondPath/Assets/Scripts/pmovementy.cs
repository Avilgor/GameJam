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
    public LayerMask playerLayer;


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

    /*void ConnectTo(Rigidbody2D player)
    {
        SliderJoint2D joint = GetComponent<SliderJoint2D>();
        joint.connectedBody = player;
    }

    void OnCollisionEnter2D(Collision2D montarse)
    {
        if (montarse.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ConnectTo(montarse.collider.GetComponent<Rigidbody2D>());
        }
    }*/


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
