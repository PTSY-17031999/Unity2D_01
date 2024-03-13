using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{


    [SerializeField] private bool Is_Over_game = false;
    [SerializeField] private bool Is_Pause_game = false;
    int Score = 0; // Điểm số
    int Time_Life; // Thời gian sống
    Manage_Ui_Gameplay Conect_Manage_Ui_Gameplay;
    Data_Controller Conect_Data_Controler;
    [SerializeField] private int _Level; // Cấp độ trong game
    Create_Enemy Conect_Create_Enemy;

    // Start is called before the first frame update
    void Start()
    {
        Conect_Manage_Ui_Gameplay = FindObjectOfType<Manage_Ui_Gameplay>();
        Conect_Data_Controler = FindObjectOfType<Data_Controller>();
        Conect_Create_Enemy = FindObjectOfType<Create_Enemy>();
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Set game over
    public void Set_Over_Game(bool is_over)
    {
        Is_Over_game = is_over;
        Conect_Manage_Ui_Gameplay.Show_Panel_Play_or_Over();
        Conect_Manage_Ui_Gameplay.Change_Score_Over(Score);
        Save_highests_core();
        Set_Pause_Game();
       
    }

    // Set Pause game
    public void Set_Pause_Game()
    {
        if(Is_Pause_game == false)
        {
            Is_Pause_game = true;
            Conect_Manage_Ui_Gameplay.Show_Image_Play_Pause(Is_Pause_game);
        }
        else
        {
            Is_Pause_game = false;
            Conect_Manage_Ui_Gameplay.Show_Image_Play_Pause(Is_Pause_game);
        }
    }

    public bool Get_Pause_Game()
    {
        return Is_Pause_game;
    }

    private void Save_highests_core()
    {
        int Previous_Score_Top_1 = PlayerPrefs.GetInt("Top_1_Score");
        int Previous_Score_Top_2 = PlayerPrefs.GetInt("Top_2_Score");
        int Previous_Score_Top_3 = PlayerPrefs.GetInt("Top_2_Score");

        if (Score >= Previous_Score_Top_1)
        {
            PlayerPrefs.SetInt("Top_1_Score", Score);
            PlayerPrefs.SetInt("Top_2_Score", Previous_Score_Top_1);
            PlayerPrefs.SetInt("Top_3_Score", Previous_Score_Top_2);

        } else if (Score >= Previous_Score_Top_2)
        {
            PlayerPrefs.SetInt("Top_2_Score", Score);
            PlayerPrefs.SetInt("Top_3_Score", Previous_Score_Top_2);
        } else if (Score >= Previous_Score_Top_3)
        {
            PlayerPrefs.SetInt("Top_3_Score", Score);
        }
    }

    // Get game over
    public bool Get_Over_Game()
    {
        return Is_Over_game;
    }

    //Sét điểm số
    public void Set_Score()
    {
        Score++;
        Conect_Manage_Ui_Gameplay.Change_Score(Score);
    }

    #region Level
    public void Set_Level_Game(float Time_Live)
    {
             if (Time_Live >= 60 && Time_Live <= 70) Conect_Create_Enemy.Return_Value_Level(2);
        else if (Time_Live >= 120 && Time_Live <= 121) Conect_Create_Enemy.Return_Value_Level(3);
        else if (Time_Live >= 180 && Time_Live <= 181) Conect_Create_Enemy.Return_Value_Level(4);
        else if (Time_Live >= 240 && Time_Live <= 241) Conect_Create_Enemy.Return_Value_Level(5);
        else if (Time_Live >= 300 && Time_Live <= 301) Conect_Create_Enemy.Return_Value_Level(6);
        else if (Time_Live >= 360 && Time_Live <= 361) Conect_Create_Enemy.Return_Value_Level(7);
        else if (Time_Live >= 420 && Time_Live <= 421) Conect_Create_Enemy.Return_Value_Level(8);
        else if (Time_Live >= 480 && Time_Live <= 481) Conect_Create_Enemy.Return_Value_Level(9);
    }
    public int Get_Level_Game()
    {
        return _Level;
    }
    #endregion













    public void No_play_Again()
    {
        SceneManager.LoadScene("Menu_game");
    }
    public void Play_Again()
    {
        SceneManager.LoadScene("Lever_1");
        Conect_Manage_Ui_Gameplay.Start();
    }
}
