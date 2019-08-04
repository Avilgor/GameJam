using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class MazeController : MonoBehaviour
{
    [SerializeField]
    AudioClip []clip;
    [SerializeField]
    GameObject []maze;
    [SerializeField]
    Text countdown;
    public GameObject win, lose;

    AudioSource audio;
    float timer;
    public bool goal;

    private System.Random rnd;

    void Start()
    {
        Cursor.visible = false;
        rnd = new System.Random();
        audio = GetComponent<AudioSource>();
        GameObject chosen = Instantiate(maze[rnd.Next(0, maze.Length)]);
        timer = 60f;
        countdown.text = "01:" + ((int)timer).ToString();
        goal = false;
    }

    void Update()
    {
        if (timer > 0) { timer -= Time.deltaTime; }     

        countdown.text = "00:"+((int)timer).ToString();

        switch ((int)timer)
        {
            case 5:                
            case 4: 
            case 3:
            case 2: if (!audio.isPlaying) { audio.PlayOneShot(clip[0]); } break; 
            case 1: if (!audio.isPlaying) { audio.PlayOneShot(clip[1]); } break;
        }

        if (timer <= 0 && goal == false)
        {
            lose.SetActive(true);
            StartCoroutine(LoadMenu(3f));
        }
        if (goal ==  true)
        {
            win.SetActive(true);
            StartCoroutine(LoadMenu(3f));
        }
    }

    IEnumerator LoadMenu(float time)
    {
        yield return new WaitForSeconds(time);
        Cursor.visible = true;
        SceneManager.LoadScene(1);
    }
}