using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Maze : MonoBehaviour
{
    [SerializeField]
    GameObject []Doors;
    //[SerializeField]
    //GameObject []objects;

    GameObject player;
    //GameObject center;

    int enter, exit;
    private System.Random rnd;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //center = GameObject.Find("ScriptHandler");

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
                /*for (int i = 0; i < objects.Length; i++)
                {
                    objects[i].transform.Rotate(0f, 0f, 0f);
                    //objects[i].transform.position = center.transform.position;
                }               */
                Debug.Log("Door 1");
                break;              

            case 1:
                transform.Rotate(0f, 0f, 90f);
                /*for (int i = 0; i < objects.Length; i++)
                {
                    objects[i].transform.Rotate(0f, -90f, 0f);
                    //objects[i].transform.position = center.transform.position;
                }*/
                Debug.Log("Door 2");
                break;
            case 2:
                transform.Rotate(0f, 0f, 180f);
                /*for (int i = 0; i < objects.Length; i++)
                {
                    objects[i].transform.Rotate(0f, -180f, 0f);
                    //objects[i].transform.position = center.transform.position;
                }*/          
                Debug.Log("Door 3");
                break;
            case 3:
                transform.Rotate(0f, 0f, 270f);
                /*for (int i = 0; i < objects.Length; i++)
                {
                    objects[i].transform.Rotate(0f, -270f, 0f);
                    //objects[i].transform.position = center.transform.position;
                }/*/
                Debug.Log("Door 4");
                break;
        }
        player.transform.position = new Vector3(Doors[enter].transform.position.x,Doors[enter].transform.position.y,-0.8f);
    }

    
    void Update()
    {
        
    }
}