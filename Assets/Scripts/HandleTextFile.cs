using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO; // have access to characters from a byte stream

public class HandleTextFile
{
    //UnityEditor allows me to create a tool in my Menus
    [MenuItem("Tools/Write File")]
    public static void WriteToString()
    {
        //at this file location
        string path = "Assets/Resources/Save/KeyBinds.txt";

        //True = add to file
        //False = overwrite file
        StreamWriter writer = new StreamWriter(path, false);
        //write each of our keys in the file
        foreach (var key in KeyBinds.keys)
        {
            //Each key name and key value will be writtein in with a : to seperate them
            writer.WriteLine(key.Key + ":" + key.Value.ToString());
        }
        //writing is done
        writer.Close();
        //re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
        TextAsset asset = Resources.Load("Save/KeyBinds.txt") as TextAsset;
    }
    //UnityEditor allows me to create a tool in my Menus
    [MenuItem("Tools/Read File")]
    public static void ReadString()
    {

        //at this file location
        string path = "Assets/Resources/Save/KeyBinds.txt";
        //Read the text from the file KeyBinds.txt
        StreamReader reader = new StreamReader(path);
        string line;
        while((line = reader.ReadLine()) != null)
        {
            string[] parts = line.Split(':');
            if(KeyBinds.keys.Count > 0)
            {
                KeyBinds.keys[parts[0]] = (KeyCode)System.Enum.Parse(typeof(KeyCode), parts[1]);
            }
            else
            {
                KeyBinds.keys.Add(parts[0], (KeyCode)System.Enum.Parse(typeof(KeyCode), parts[1]));
            }
            
        }
        reader.Close();
    }
}
