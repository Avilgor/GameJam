using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    public ParticleSystem effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag ( "Player" ))
        {
            effect.Play();
            Globals.globaltimerR = 0;
            Globals.timerstop = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Globals.globaltimerR = 0;
            Globals.timerstop = false;
        }

    }
}
