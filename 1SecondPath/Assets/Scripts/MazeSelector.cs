using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MazeSelector : MonoBehaviour
{
    [SerializeField]
    GameObject []maze;

    private System.Random rnd;

    void Start()
    {
        rnd = new System.Random();
        GameObject chosen = Instantiate(maze[rnd.Next(0, maze.Length)]);
    }
}