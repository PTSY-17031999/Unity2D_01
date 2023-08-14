using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Controller : MonoBehaviour
{
    public AudioSource Conect_files_Source;
    public AudioClip Panda_Moving_sound;
    public AudioClip Panda_Dead_sound;

    public void Play_Panda_Dead_sound() { 
         if (Conect_files_Source && Panda_Dead_sound)
            {
                Conect_files_Source.PlayOneShot(Panda_Dead_sound);
            }}
}
