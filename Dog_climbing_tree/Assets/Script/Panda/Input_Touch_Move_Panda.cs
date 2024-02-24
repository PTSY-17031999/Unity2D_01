using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Touch_Move_Panda : MonoBehaviour
{
    Vector2 Start_Position, End_Position;
    float Distance;
    float Start_Time, End_Time;
    bool Attack = false;
    Move_Panda Conect_SMP;
    Vector2 Panda_Come_here; // Vị trí Panda sẽ tới khi di chuyển theo hướng Y
    bool InTouch_Panda_Down, InTouch_Panda_Top; // Trả về Touch có đang yêu cầu di chuyển lên hay không 
    



    // Test function Touch mobile
    #region Test function touch mobile
    Manage_Ui_Gameplay Conect_Test;

    #endregion



    void Start() {
        Conect_Test = FindObjectOfType<Manage_Ui_Gameplay>();
        Conect_SMP = FindObjectOfType<Move_Panda>();
        InTouch_Panda_Down = false; InTouch_Panda_Top = false;
    }



    float Time_Attack_Delay = 0;
    int No_Attack = 0;
    void Update()
    {
        #region Kiểm tra điểm bắt đầu chạm
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Start_Time = Time.time;
            Start_Position = Input.GetTouch(0).position;

        }
        #endregion

        #region Kiểm tra có dùng chức năng tấn công không
        if (Start_Time + 0.18f <= Time.time && Start_Time != 0)
        {
            Attack = true;
            Time_Attack_Delay = 0.58f;
            Distance = 0;
        }
        //if(Attack != false)
        Time_Attack_Delay -= Time.deltaTime;

        #endregion


        #region Kiểm tra điểm kết thúc chạm
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)// nếu thả ngón tay
        {
            Start_Time = 0;
            Attack = false;
            if (Time_Attack_Delay < 0) End_Touch();
            else {
                Time_Attack_Delay = 0;
                No_Attack++;
                return; 
            }
                
        }
        #endregion


       
        #region Thực hiện lệnh cho di chuyển theo Y
        if (Distance > 0 && Panda_Come_here.y >= transform.position.y)
        {
            if (Panda_Come_here.y <= transform.position.y)
            {
                Distance = 0;
            }
            InTouch_Panda_Top = true;
            return;

        }else InTouch_Panda_Top = false; 


        if (Distance < 0 && Panda_Come_here.y <= transform.position.y)
        {
            if (Panda_Come_here.y >= transform.position.y)
            {
                Distance = 0;
            }
            InTouch_Panda_Down = true;
            return;
        }else InTouch_Panda_Down = false;
        #endregion



    }



    // Fuction xử lý hướng di chuyển qua lại
    private void End_Touch()
    {
        End_Position = Input.GetTouch(0).position;

        #region Vuốt theo hướng X
        if (Math.Abs(Start_Position.x - End_Position.x) > Math.Abs(Start_Position.y - End_Position.y))
        {
            if(End_Position.x > Start_Position.x)
            {
                // Giống phím D
                Conect_SMP.Panda_Move_Right();
            }
            if (End_Position.x < Start_Position.x)
            {
                // Giống phím A
                Conect_SMP.Panda_Move_Left();
            }
        }
        #endregion

        #region Vuốt theo hướng Y
        if (Math.Abs(Start_Position.x - End_Position.x) < Math.Abs(Start_Position.y - End_Position.y))
        {
            Distance = (End_Position.y - Start_Position.y)/280;
            Panda_Come_here = new Vector2(0, transform.position.y + Distance);
            

        }
        #endregion
    }




    public bool Input_Touch_Attack()
    {
        return Attack;
    }
    public bool Get_InTouch_Panda_Down()
    {
        return InTouch_Panda_Down;
    }
    public bool Get_InTouch_Panda_Top()
    {
        return InTouch_Panda_Top;
    }





    /*
     * Kiểm tra sử lý
    Conect_Test._Set_Text("");
     
     
     */
}