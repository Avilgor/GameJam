using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desaparecery : MonoBehaviour
{

    public float time;
    public SpriteRenderer sprender;
    float timer;
    EdgeCollider2D edgy;
    public LayerMask playerLayer;
    Vector2 rayposition;
    Vector2 raydirection;
    public float raydistance;



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

        if (timer >= time && !edgy.IsTouchingLayers(playerLayer) && Globals.globaltimerR >= time && !Globals.death)
        {
            sprender.enabled = false;
        }

        else if (timer >= time && edgy.IsTouchingLayers(playerLayer) && Globals.globaltimerR >= time && !Globals.death)
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

        rayposition = transform.position + new Vector3(0, 0.1f, 0);
        raydirection = transform.up;

        Debug.DrawRay(rayposition, raydirection * raydistance, Color.green);
        Debug.DrawRay(rayposition + new Vector2(0.35f, 0), raydirection * raydistance, Color.red);
        Debug.DrawRay(rayposition + new Vector2(-0.55f, 0), raydirection * raydistance, Color.cyan);
        RaycastHit2D hitplayer = Physics2D.Raycast(rayposition, raydirection, raydistance, playerLayer);
        RaycastHit2D hitplayer1 = Physics2D.Raycast(rayposition + new Vector2(0.35f, 0), raydirection, raydistance, playerLayer);
        RaycastHit2D hitplayer2 = Physics2D.Raycast(rayposition + new Vector2(-0.35f, 0), raydirection, raydistance, playerLayer);
        RaycastHit2D hitplayer3 = Physics2D.Raycast(rayposition + new Vector2(0.55f, 0), raydirection, raydistance, playerLayer);
        RaycastHit2D hitplayer4 = Physics2D.Raycast(rayposition + new Vector2(-0.55f, 0), raydirection, raydistance, playerLayer);

        if (hitplayer.collider != null || hitplayer1.collider != null || hitplayer2.collider != null
            || hitplayer3.collider != null || hitplayer4.collider != null)
        {
            timer = 0;
            print(timer);
        }
    }
}
