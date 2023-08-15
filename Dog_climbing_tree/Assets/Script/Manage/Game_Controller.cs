using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{


    public bool Is_Over_game = false;
    int Score = 0; // Điểm số
    int Time_Life; // Thời gian sống
    Manage_Ui_Gameplay Conect_Manage_Ui_Gameplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Sét game over
    public void Set_Over_Game(bool is_over)
    {
        Is_Over_game = is_over;
        Debug.Log("Game Over");
    }

    // Gét game over
    public bool Get_Over_Game()
    {
        return Is_Over_game;
    }

    //Sét điểm số
    public void Set_Score(int Score)
    {
        this.Score += Score;
        Conect_Manage_Ui_Gameplay.Change_Score(this.Score);
    }
}
