using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class MazeController : MonoBehaviour
{
    [SerializeField]
    GameObject []maze;
    [SerializeField]
    Text countdown;

    float timer;

    private System.Random rnd;

    void Start()
    {
        Cursor.visible = false;
        rnd = new System.Random();
        GameObject chosen = Instantiate(maze[rnd.Next(0, maze.Length)]);
        timer = 60f;
        countdown.text = "01:" + ((int)timer).ToString();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        countdown.text = "00:"+((int)timer).ToString();
    }
}