using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pmovementx : MonoBehaviour
{

    public float pmaxx;
    public float pminx;
    public float pspeedy;
    bool pright;
    Rigidbody2D rbp;
    bool pmoveright;

    // Start is called before the first frame update
    void Start()
    {
        rbp = GetComponent<Rigidbody2D>();
        pright = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= pmaxx && pright)
        {
            pmoveright = false;
            pright = false;

        }

        else if (transform.position.x <= pminx && !pright)
        {
            pmoveright = true;
            pright = true;
        }
    }

    void FixedUpdate()
    {
        if (pright)
        {
            rbp.MovePosition(transform.position + transform.right * Time.fixedDeltaTime);
        }

        if (!pright)
        {
            rbp.MovePosition(transform.position + -transform.right * Time.fixedDeltaTime);
        }
    }
}