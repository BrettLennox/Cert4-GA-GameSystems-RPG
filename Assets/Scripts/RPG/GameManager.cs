using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GamePlayState gamePlayState;
    public static Vector3 scr;

    // Start is called before the first frame update
    void Start()
    {
        scr.x = Screen.width / 16;
        scr.y = Screen.height / 9;
        gamePlayState = GamePlayState.Game;
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.width / 16 != scr.x)
        {
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;
        }
        switch (gamePlayState)
        {
            case GamePlayState.PreGame:
                DisplayMouse();
                break;
            case GamePlayState.Game:
                HideAndLockMouse();
                break;
            case GamePlayState.MenuPause:
                DisplayMouse();
                break;
            case GamePlayState.PostGame:
                HideAndLockMouse();
                break;
            default:
                DisplayMouse();
                break;
        }
    }

    private void DisplayMouse()
    {
        if (!Cursor.visible)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void HideAndLockMouse()
    {
        if (Cursor.visible)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
/*
enums are what we call state value variables
they are comma seperated lists of identifiers
we can use them to create types and categories
*/
public enum GamePlayState
{
    PreGame,
    Game,
    MenuPause,
    PostGame
}
