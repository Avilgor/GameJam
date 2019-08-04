using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desaparecerEnemigo : MonoBehaviour
{

    public float time;
    public SpriteRenderer sprender;
    float timer;
    BoxCollider2D boxyE;
    public LayerMask playerLayer;
    public Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        sprender = GetComponent<SpriteRenderer>();
        boxyE = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= time && !boxyE.IsTouchingLayers(playerLayer))
        {
            anim.enabled = false;
            sprender.enabled = false;
        }

        else if (timer >= time && boxyE.IsTouchingLayers(playerLayer))
        {
            sprender.enabled = true;
            anim.enabled = true;
            timer = 0;

        }



    }
}
