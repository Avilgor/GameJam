using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Encription
{ 
    string EncriptDecript(string toEncrypt)
    {        
        char []key = { 'K', 'C', 'Q', 'H', 'X', 'P' }; //Any chars will work, in an array of any size
        StringBuilder output = new StringBuilder();

        for (int i = 0; i < toEncrypt.Length; i++)
        {
            output.Append((char)((uint)toEncrypt[i] ^ (uint)key[i % key.Length]));
        }
        return output.ToString();
    }
}