using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desaparecer : MonoBehaviour
{

    public float time;
    public SpriteRenderer sprender;
    float timer;
    EdgeCollider2D edgy;

    Rigidbody2D rbp;

    // Start is called before the first frame update
    void Start()
    {
        sprender = GetComponent<SpriteRenderer>();
        rbp = GetComponent<Rigidbody2D>();
        edgy = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time && !edgy.IsTouchingLayers(9))
        {
            sprender.enabled = false;
        }
        if (edgy.IsTouchingLayers(9))
        {
            print("está tocando");
        }
    }
}
