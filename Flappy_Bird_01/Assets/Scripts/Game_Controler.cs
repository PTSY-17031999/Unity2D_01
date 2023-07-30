using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Controler : MonoBehaviour
{
    int Score; //Lưu điểm
    int High_score;  //Lưu điểm cao nhất
    Pipe_Controler _Pipe_Controler;
    Ui_Controler _UI;
    Bird _bird;
    bool Game_over; //Kiểm tra game over
    public Bird Bird;

    

    void Start()
    {
        Game_over = false; // Set game over false để chưa kết thúc game
        Score = 0;

       _Pipe_Controler = FindObjectOfType<Pipe_Controler>();
        _bird = FindObjectOfType<Bird>();
        _UI = FindObjectOfType<Ui_Controler>();
       _Pipe_Controler.Inset_pipe();


        // Tính năng chọn nhân vật đang xây dựng
        _UI.setShowOrHidePanellStar(false);
        //Pause_game(); // Tạm dừng game khi chưa chọn nhân vật 
        // CHARACTER_CHOICE_File(); // kiểm tra xem đã lựa chọn nhân vặt chưa
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
         High_score = PlayerPrefs.GetInt("High_score"); 
        _UI.Show_Score_on_Panel_Over(Score, High_score);
        _UI.setShowOrHidePanellOver(true);
    }

    // Tăng điểm
    public void Plub_Score(int score)
    {
        if (!Game_over)
            Score += score;
        if (Score >= High_score)
        {
            High_score = Score;
            PlayerPrefs.SetInt("High_score", High_score); // Lưu điểm cao nhất vào file ghi lại
            //int value = PlayerPrefs.GetInt("High_score"); câu lệnh lấy điểm ra
        }

        _UI.Show_Score_on_Panel(Score);
    }

    // Trả về điểm số
    public int Get_Score()
    {
        return Score;
    }

    // Trả về điểm cao nhất
    public int Get_High_Score()
    {
        return High_score;
    }

    public bool Get_Over_Game()
    {
        return Game_over;
    }
    public void Set_Over_Game(bool _Over_game)
    {
        Game_over = _Over_game;
        if (Game_over == true)
        {
            GameOver();
        }
    }

    public void Play_Again()
    {
        SceneManager.LoadScene("Scene_1");
    }

    bool _Pause = false;
    float Location_Y_Bird;
    public void Pause_game()
    {
        if (_Pause)
        {
            if (Bird)// NẾU VẬT CẢN CHƯA GÁN VÀO THÌ KHÔNG CHẠY
            {
                Instantiate(Bird, new Vector2(-1.07f, Location_Y_Bird), Quaternion.identity);
            }
            _Pause = false;
        }
        else if(!_Pause) {
            Location_Y_Bird = _bird.Get_vi_tri_Bird();
            _Pause = true;
             }

        
    }
    public bool Get_Pause_Game()
    {
        return _Pause;
    }


    bool _Chose_Character_Blue; // True mầu xanh, False mầu đỏ

    //Lựa chọn nhân vặt khi đã lưu lựa chọn lại
    void CHARACTER_CHOICE_File()
    {
        if( PlayerPrefs.GetInt("CHARACTER_CHOICE") == 0) return;
        if (PlayerPrefs.GetInt("CHARACTER_CHOICE") == 1)
        {
            CHARACTER_CHOICE(true);
        }
        if (PlayerPrefs.GetInt("CHARACTER_CHOICE") == 2)
        {
            CHARACTER_CHOICE(false);
        }
        _UI.setShowOrHidePanellStar(false);
    }


        // Lựa chọn nhân vặt qua button
        public void CHARACTER_CHOICE(bool _chose)
    {
        _Chose_Character_Blue = _chose;
        if (_chose)
        {
            PlayerPrefs.SetInt("CHARACTER_CHOICE", 1);
        }
        else if(!_chose){
            PlayerPrefs.SetInt("CHARACTER_CHOICE", 2);
        }

        
        Debug.Log(_chose);
        _UI.setShowOrHidePanellStar(false);
        Pause_game(); // Cho game chạy lại khi đã chọn nhân vặt
    }
}
