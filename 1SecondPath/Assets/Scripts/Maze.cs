using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Maze : MonoBehaviour
{
    [SerializeField]
    GameObject []Doors;
    [SerializeField]
    GameObject mesh;

    GameObject player;

    float timer;
    private int enter, exit;
    private System.Random rnd;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timer = 0f;
        rnd = new System.Random();
        enter = rnd.Next(0, Doors.Length);

        do
        {
            exit = rnd.Next(0, Doors.Length);
        } while (exit != enter);

        switch (enter)
        {
            case 0:
                transform.Rotate(0f, 0f, 0f);      
                Debug.Log("Door 1");
                break;              

            case 1:
                transform.Rotate(0f, 0f, 90f);
                Debug.Log("Door 2");
                break;
            case 2:
                transform.Rotate(0f, 0f, 180f);        
                Debug.Log("Door 3");
                break;
            case 3:
                transform.Rotate(0f, 0f, 270f);
                Debug.Log("Door 4");
                break;
        }
        player.transform.position = new Vector3(Doors[enter].transform.position.x,Doors[enter].transform.position.y,-0.8f);
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3)
        {
            mesh.SetActive(false);
        }
    }
}