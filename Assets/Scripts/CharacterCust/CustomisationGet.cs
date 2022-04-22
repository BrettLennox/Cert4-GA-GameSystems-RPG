using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CustomisationGet : MonoBehaviour
{
    public Renderer character;

    // Start is called before the first frame update
    void Start()
    {
        //load
        character = GetComponent<Renderer>();
        Load();
    }

    void Load()
    {

        string path = "Assets/Resources/Save/CharacterSave.txt";

        StreamReader reader = new StreamReader(path);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] parts = line.Split(':');
        }

        SetTexture("Skin", 0);
        SetTexture("Hair", 0);
        SetTexture("Mouth", 0);
        SetTexture("Eyes", 0);
        SetTexture("Clothes", 0);
        SetTexture("Armour", 0);
        reader.Close();
    }

    // Update is called once per frame
    void SetTexture(string type, int index)
    {
        Texture2D texture = null;
        int matIndex = 0;
        switch (type)
        {
            case "Skin":
                texture = Resources.Load("Character/Skin_" + index) as Texture2D;
                matIndex = 1;
                break;
            case "Hair":
                texture = Resources.Load("Character/Hair_" + index) as Texture2D;
                matIndex = 2;
                break;
            case "Mouth":
                texture = Resources.Load("Character/Mouth_" + index) as Texture2D;
                matIndex =3;
                break;
            case "Eyes":
                texture = Resources.Load("Character/Eyes_" + index) as Texture2D;
                matIndex = 4;
                break;
            case "Clothes":
                texture = Resources.Load("Character/Clothes_" + index) as Texture2D;
                matIndex = 5;
                break;
            case "Armour":
                texture = Resources.Load("Character/Armour_" + index) as Texture2D;
                matIndex = 6;
                break;

        }
        Material[] mats = character.materials;
        mats[matIndex].mainTexture = texture;
        character.materials = mats;
    }
}
