using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;


public class ReadCompletions : MonoBehaviour
{
    void Start()
    {
        string localPath = Application.dataPath + "/Save/SaveData.sav";
        if (!Directory.Exists(Application.dataPath + "/Save"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Save");
        }              
        Encription decript = new Encription();
        
        if (!File.Exists(localPath))
        {
            StreamWriter writer = new StreamWriter(localPath);
            writer.Write(decript.EncriptDecript("You finished the maze /0/ times!"));
            writer.Close();
        }
        //try
        //{
        StreamReader reader = new StreamReader(localPath);
        string[] output = decript.EncriptDecript(reader.ReadLine()).Split('/');
        reader.Close();
        GetComponent<Text>().text = output[0] + output[1] + output[2];
        Globals.mazeWins = Int32.Parse(output[1]);
    }
}