using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit_game : MonoBehaviour
{
    public void exitgame()
    {
        // Tắt game
        Application.Quit();
        Debug.Log("Exit game");
    }
}
