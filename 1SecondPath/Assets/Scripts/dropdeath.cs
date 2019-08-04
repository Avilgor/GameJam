using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dropdeath : MonoBehaviour
{
    int escenaActual;
    // Start is called before the first frame update
    void Start()
    {
        escenaActual = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            StartCoroutine("muerte");
        }
    }

    IEnumerator muerte()
    {
        Globals.death = true;
        Globals.globaltimerR = 0;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(escenaActual);
        Globals.death = false;
    }
}
