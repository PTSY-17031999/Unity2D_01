using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manage_menus : MonoBehaviour
{

    public GameObject Panel_play;
    public GameObject Panel_Score;
    public GameObject Panel_Ruler;
    public GameObject Panel_Quit_Game;
    

    public GameObject Image_Button_on_Audio;
    public GameObject Image_Button_off_Audio;
    Audio_Controller Conect_Audio_Controler;


    private void Start()
    {
        On_Off_Audio();
    }


    // Click Back các panel
    public void Back_Pannel()
    {
           // Panel_play.SetActive(false);
            Panel_Score.SetActive(false);
            Panel_Ruler.SetActive(false);
            Panel_Quit_Game.SetActive(false);  
    }


    // Click hiện các pannel
    public void Show_Pannel(int Miss)
    {
        //Play
        if(Miss == 1)
        {
            Panel_play.SetActive(true);
        }
        //Panel_Score
        if (Miss == 2)
        {
            High_score_handling();
            Panel_Score.SetActive(true);
        }
        //Panel_Ruler
        if (Miss == 3)
        {
            Panel_Ruler.SetActive(true);
        }
        //Quit game
        if (Miss == 4)
        {
            Panel_Quit_Game.SetActive(true);
        }
    }

    // Click play game
    public void Button_Play()
    {
        SceneManager.LoadScene("Lever_1");
    }


    bool on_off_audio; // on
    // Click on or off audio
    public void On_Off_Audio()
    {

        if (PlayerPrefs.GetInt("Audio_play") == 0) on_off_audio = false;
        else if (PlayerPrefs.GetInt("Audio_play") == 1) on_off_audio = true;
        else on_off_audio = true;


        Conect_Audio_Controler = FindObjectOfType<Audio_Controller>();
        if (on_off_audio == true)
        { //Off
            on_off_audio = false;
            PlayerPrefs.SetInt("Audio_play", 0);
            Image_Button_on_Audio.SetActive(on_off_audio);
            Image_Button_off_Audio.SetActive(!on_off_audio);
        }
        else
        { //on
                on_off_audio = true;
                PlayerPrefs.SetInt("Audio_play", 1);
                Image_Button_on_Audio.SetActive(on_off_audio);
                Image_Button_off_Audio.SetActive(!on_off_audio);
        }
        Conect_Audio_Controler.Check_On_Off_Audio();
    }


    public void Quit_game()
    {
        // Tắt game
        Application.Quit();
        Debug.Log("Exit game");
    }


    public Text Text_Top_1_Score;
    public Text Text_Top_2_Score;
    public Text Text_Top_3_Score;
    void High_score_handling()
    {
        if(Text_Top_1_Score && Text_Top_2_Score && Text_Top_3_Score)
        {
            Text_Top_1_Score.text = PlayerPrefs.GetInt("Top_1_Score").ToString();
            Text_Top_2_Score.text = PlayerPrefs.GetInt("Top_2_Score").ToString();
            Text_Top_3_Score.text = PlayerPrefs.GetInt("Top_3_Score").ToString();
        }
        
    }
}
