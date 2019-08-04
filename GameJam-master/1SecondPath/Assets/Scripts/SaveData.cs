using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveData : MonoBehaviour
{
    private void Start()
    {
        Encription encript = new Encription();
        Globals.mazeWins++;
        string localPath = Application.dataPath + "/StreamingAssets/SaveData.sav";
        StreamWriter writer = new StreamWriter(localPath);
        writer.WriteLine(encript.EncriptDecript("You finished the maze /"+Globals.mazeWins+"/ times!"));
        writer.Close();
    }
}
