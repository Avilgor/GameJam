using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Maze : MonoBehaviour
{
    [SerializeField]
    GameObject []Doors;

    private System.Random rnd;

    void Start()
    {
        rnd = new System.Random();
        
    }

    
    void Update()
    {
        
    }
}