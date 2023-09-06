using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Controller : MonoBehaviour
{
    public AudioSource Conect_files_Source;
    public AudioClip Panda_Moving_sound;
    public AudioClip Enemy_Dead_sound;
    public AudioClip Panda_Dead_sound;
    public AudioClip Click_Button_sound;

    public void Play_Panda_Dead_sound() { 
         if (Conect_files_Source && Panda_Dead_sound)
            {
                Conect_files_Source.PlayOneShot(Panda_Dead_sound);
            }}
    public void Play_Enemy_Dead_sound()
    {
        if (Conect_files_Source && Enemy_Dead_sound)
        {
            Conect_files_Source.PlayOneShot(Enemy_Dead_sound);
        }
    }
    public void Play_Panda_Moving_sound()
    {
        if (Conect_files_Source && Panda_Moving_sound)
        {
            Conect_files_Source.PlayOneShot(Panda_Moving_sound);
        }
    }
    public void Play_Click_Button_sound()
    {
        if (Conect_files_Source && Click_Button_sound)
        {
            Conect_files_Source.PlayOneShot(Click_Button_sound);
        }
    }

    private void Start()
    {
        Check_On_Off_Audio();

    }

    public void Check_On_Off_Audio()
    {
        if (PlayerPrefs.GetInt("Audio_play") == 0)
        {
            Conect_files_Source.Stop();
        }
        else Conect_files_Source.Play();
    }
}
