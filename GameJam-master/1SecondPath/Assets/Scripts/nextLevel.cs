using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{

    int escenaActual;
    public ParticleSystem effect;
    // Start is called before the first frame update
    void Start()
    {
        escenaActual = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            StartCoroutine("next");
        }
    }

    IEnumerator next ()
    {
        Globals.death = true;
        Globals.globaltimerR = 0;
        effect.Play();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(escenaActual + 1);
    }
}
