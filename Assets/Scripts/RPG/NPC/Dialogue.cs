using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string[] text;
    public int index;
    public bool showDlg;

    void OnGUI()
    {
        if (showDlg)
        {
            //box
            //entire bottom third of the screen
            GUI.Box(new Rect(GameManager.scr.x * 0, GameManager.scr.y * 6,
            GameManager.scr.x * 16, GameManager.scr.y * 3), text[index]);
            //if we are not at the end of our conversation
            if (index < text.Length - 1)
            {
                if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f,
                    GameManager.scr.x * 1, GameManager.scr.y * 0.5f), "Next"))
                {
                    index++;
                }
            }
            else
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
