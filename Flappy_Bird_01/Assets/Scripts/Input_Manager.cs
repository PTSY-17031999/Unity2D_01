using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("This is input_manger star");
        Input_key();
    }

    // Update is called once per frame
    void Update()
    { 
        // Input Mouse
        bool Star_click = Input.GetMouseButton(0);
        bool hold_mouse = Input.GetButtonDown("A");
       // Debug.Log(hold_mouse);
    }
        







        // Input Key
      

        static void Input_key()
        {
            bool Bat_dau_nhan_phim = Input.GetKeyDown(KeyCode.A); // Bắt đầu nhấn phím
            bool Bat_dau_giu_phim = Input.GetKey(KeyCode.A);    // Bắt đầu Giuwx phím
            bool Bat_dau_nha_phim = Input.GetKeyUp(KeyCode.A);    // Bắt đầu nhả phím

            if (Bat_dau_nhan_phim)
            {
                Debug.Log("Đang nhắn phím");
            }

            if (Bat_dau_giu_phim)
            {
                Debug.Log("Đang Giuwx phím");
            }
            if (Bat_dau_giu_phim)
            {
                Debug.Log("Đang Giuwx phím");
            }
        }
    }

