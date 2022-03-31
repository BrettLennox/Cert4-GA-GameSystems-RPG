using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOneChoiceApproval : DialogueOneChoice
{
    [Header("How much the NPC likes us")]
    public int approval;
    [Header("The dialogue based on text")]
    public string[] likeText;
    public string[] neutralText;
    public string[] dislikeText;

    private void Start()
    {
        approval = 0;
        ChangeDialogue(approval);
    }

    void ChangeDialogue(int approval)
    {
        if (approval <= -1)
        {
            text = dislikeText;
        }
        else if (approval == 0)
        {
            text = neutralText;
        }
        else if (approval >= 1)
        {
            text = likeText;
        }
    }

    void OnGUI()
    {
        if (showDlg)
        {
            GUI.Box(new Rect(GameManager.scr.x * 0, GameManager.scr.y * 6,
                GameManager.scr.x * 16, GameManager.scr.y * 3), text[index]);

            if (index < text.Length - 1 && index != choiceIndex)
            {
                if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f,
                    GameManager.scr.x * 1, GameManager.scr.y * 0.5f), "Next"))
                {
                    index++;
                }
            }
            else if (index == choiceIndex)
            {
                //positive - increase like
                if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f,
                    GameManager.scr.x * 1, GameManager.scr.y * 0.5f), "Yes"))
                {
                    if (approval < 1)
                    {
                        approval++;
                    }
                    index++;
                    ChangeDialogue(approval);
                }

                //negative - decrease like
                if (GUI.Button(new Rect(GameManager.scr.x * 14, GameManager.scr.y * 8.5f,
                    GameManager.scr.x * 1, GameManager.scr.y * 0.5f), "No"))
                {
                    if (approval > -1)
                    {
                        approval--;
                    }
                    index = text.Length - 1;
                    ChangeDialogue(approval);
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
