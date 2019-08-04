using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class desaparecerEnemigo : MonoBehaviour
{

    public float time;
    public SpriteRenderer sprender;
    float timer;
    BoxCollider2D boxyE;
    public LayerMask playerLayer;
    public Animator anim;
    int escenaActual;
    public ParticleSystem effect;
    



    // Start is called before the first frame update
    void Start()
    {
        sprender = GetComponent<SpriteRenderer>();
        boxyE = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        escenaActual = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer >= time && !boxyE.IsTouchingLayers(playerLayer) && Globals.globaltimerR >= time)
        {
            anim.enabled = false;
            sprender.enabled = false;
        }

        else
        {
            sprender.enabled = true;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            StartCoroutine ("muerte");
        }
    }

    IEnumerator muerte()
    {
        Globals.globaltimerR = 0;
        sprender.enabled = true;
        anim.enabled = true;
        timer = 0;
        effect.Play();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(escenaActual);
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
    }
}
