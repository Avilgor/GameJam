using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desaparecer : MonoBehaviour
{

    public float time;
    public SpriteRenderer sprender;
    float timer;
    EdgeCollider2D edgy;
    public LayerMask playerLayer;



    // Start is called before the first frame update
    void Start()
    {
        sprender = GetComponent<SpriteRenderer>();
        edgy = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= time && !edgy.IsTouchingLayers(playerLayer))
        {
            sprender.enabled = false;
        }

        else if (timer >= time && edgy.IsTouchingLayers(playerLayer))
        {
            sprender.enabled = true;
            timer = 0;
            
        }


        
    }
}
