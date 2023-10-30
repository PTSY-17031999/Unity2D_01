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
   
    // Start is called before the first frame update
    void Start()
    {
        Conect_Manage_Ui_Gameplay = FindObjectOfType<Manage_Ui_Gameplay>();
        Conect_Data_Controler = FindObjectOfType<Data_Controller>();
       

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
        Debug.Log("Game Over");
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

    // Gét game over
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
