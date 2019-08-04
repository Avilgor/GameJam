using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Maze : MonoBehaviour
{
    [SerializeField]
    GameObject []Doors;
    [SerializeField]
    GameObject[] doorWalls;
    [SerializeField]
    GameObject mesh;

    GameObject player;
    GameObject head;

    float timer;
    private int enter, exit;
    private System.Random rnd;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        head = GameObject.FindGameObjectWithTag("Goal");
        timer = 0f;
        rnd = new System.Random();
        enter = rnd.Next(0, Doors.Length);

        do
        {
            exit = rnd.Next(0, Doors.Length);           
        } while (exit == enter);
        switch (enter)
        {
            case 0:
                transform.Rotate(0f, 0f, 0f);      
                break;              
            case 1:
                transform.Rotate(0f, 0f, 90f);
                break;
            case 2:
                transform.Rotate(0f, 0f, 180f);        
                break;
            case 3:
                transform.Rotate(0f, 0f, 270f);
                break;
        }

        Doors[exit].GetComponent<BoxCollider>().enabled = false;
        doorWalls[enter].SetActive(false);
        doorWalls[exit].SetActive(false);

        head.transform.position = new Vector3(Doors[exit].transform.position.x, Doors[exit].transform.position.y, -0.8f);
        player.transform.position = new Vector3(Doors[enter].transform.position.x,Doors[enter].transform.position.y+0.5f,-0.8f);
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2)
        {
            mesh.SetActive(false);
            for (int i = 0; i < doorWalls.Length; ++i)
            {
                if (i != enter && i != exit)
                {
                    doorWalls[i].GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
    }
}