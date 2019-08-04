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
        timer = 0;
        Globals.globaltimerR = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer >= time && !edgy.IsTouchingLayers(playerLayer) && Globals.globaltimerR >= time)
        {
            sprender.enabled = false;
        }

        else if (timer >= time && edgy.IsTouchingLayers(playerLayer) && Globals.globaltimerR >= time)
        {
            sprender.enabled = true;
            timer = 0;
            
        }
        
        else
        {
            sprender.enabled = true;
        }


        
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        Globals.globaltimerR += Time.deltaTime;
    }
}
