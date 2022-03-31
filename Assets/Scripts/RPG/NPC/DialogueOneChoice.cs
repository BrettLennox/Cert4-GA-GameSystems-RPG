using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOneChoice : Dialogue
{
    public int choiceIndex;

    void OnGUI()
    {
        if (showDlg)
        {
            GUI.Box(new Rect(GameManager.scr.x * 0, GameManager.scr.y * 6,
                GameManager.scr.x * 16, GameManager.scr.y * 3), text[index]);

            if (index < text.Length - 1 && index != choiceIndex) //not choice
            {
                if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f,
                    GameManager.scr.x * 1, GameManager.scr.y * 0.5f), "Next"))
                {
                    index++;
                }
            }
            else if (index == choiceIndex) // choice
            {
                if (GUI.Button(new Rect(GameManager.scr.x * 14, GameManager.scr.y * 8.5f,
                    GameManager.scr.x * 1, GameManager.scr.y * 0.5f), "Yes"))
                {
                    index++;
                }
                if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f,
                    GameManager.scr.x * 1, GameManager.scr.y * 0.5f), "No"))
                {
                    index = text.Length - 1;
                }
            }
            else// bye
            {
                if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f,
                    GameManager.scr.x * 1, GameManager.scr.y * 0.5f), "Bye"))
                {
                    index = 0;
                    showDlg = false;
                    GameManager.gamePlayState = GamePlayState.Game;
                }
            }

        }
    }
}
