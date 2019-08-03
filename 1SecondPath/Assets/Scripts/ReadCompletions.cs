using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class ReadCompletions : MonoBehaviour
{
    void Start()
    {
        Encription decript = new Encription();
        string localPath = Application.dataPath + "/StreamingAssets/SaveData.txt";
        StreamReader reader = new StreamReader(localPath);
        string output = reader.ReadLine();       
        reader.Close();
        GetComponent<Text>().text = decript.EncriptDecript(output);
    }
}