using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveData 
{
    public static string localPath = Application.dataPath + "/StreamingAssets/SaveData.txt";
    StreamWriter writer = new StreamWriter(localPath, true);
    StreamReader reader = new StreamReader(localPath);

    public  void writeData(String input)
    {
        
        writer.WriteLine(input);
        writer.Close();
    }

    public string readData(bool close = false)
    {
        string output="";
        output = reader.ReadLine();
        if (close)
        {
            reader.Close();
        }
        return output;
    }
}
