using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Move_Panda : MonoBehaviour
{
    
    float speed; // Tốc độ
    public Path _path;
    private List<Vector3> _Path = new List<Vector3>();
    int location_tree_and_side = 6;
    int Last_Location = -1 ;
    bool Check_pressed_space; //nút space được nhân khi tấn công
    public float Save_location_Y; // Lưu lại vị trí trước khi tấn công

    Panda Panda;
    Panda_Animation_Controller Conect_P_A_C;
    Game_Controller Conect_Game_Controler;
    Input_Touch_Move_Panda Conect_ITMP;


    private void Start()
    {
        Conect_Game_Controler = FindObjectOfType<Game_Controller>();
        Panda = FindObjectOfType<Panda>();
        Conect_P_A_C = FindObjectOfType<Panda_Animation_Controller>();
        Panda.Choose_Panda(Last_Location, location_tree_and_side);
        Conect_ITMP = FindObjectOfType<Input_Touch_Move_Panda>();

    }



    // Set than số cho Panda di chuyển
    public void Set_Star( float speed)
    {
        this.speed = speed; // Sét tốc độ bằng tốc độ Panda.
        _Path = _path.GetListPosition();
       
        transform.position = new Vector3(_Path[location_tree_and_side].x, transform.position.y, transform.position.z); // sét đối tượng về vị trí bắt đàu di chuyển
    }


    // Biến lưu kiểm tra ainmation di chuyển qua lại đang hoạt động
    //bool back_and_forth_function_is_active = false;

    private void Update()
    {
        if ( Panda.Get_Game_Over() == false && (!(Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))))
        {
            Conect_P_A_C.Set_Status(0);
        }

        if (Conect_Game_Controler.Get_Pause_Game() == true) return;
        Attack();
        if (Check_pressed_space == false)
        { 
            Movement();
        }
        
    }


    bool conversion_step = false;
    bool W_key_after_attacking = false; // Lưu lại Phim W được nhắn sau khi tấn công
    private void Attack()
    {

        if (Input.GetKey(KeyCode.Space) || Conect_ITMP.Input_Touch_Attack() == true)
        {
            Check_pressed_space = true;
            conversion_step = true;

            // Cho panda tấn công xuống
            if (_Path[0].y <= transform.position.y)
            {
                transform.position -= new Vector3(0, speed * Time.deltaTime, 0); // Cho đối tượng di chuyển
                Conect_P_A_C.Set_Status(3);
            }

        }
        else
        {
            Check_pressed_space = false;
            //Conect_P_A_C.Set_Status(0);
        }

        //Luu lại vị trí cũ trước khi tấn công 
        if (conversion_step != true) 
            Save_location_Y = transform.position.y;
        


        // Cho panda về vị trí cũ nếu vừa tấn công
        if (W_key_after_attacking == true)
        {
            Conect_P_A_C.Set_Status(2);
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            //kiểm tra xem panda đã về vị trí trước khi tấn công chưa
            if (transform.position.y >= Save_location_Y)
            {
                //Conect_P_A_C.Set_Status(0);
                conversion_step = false;
                W_key_after_attacking = false;

            }
        }
    }

    // Trả về Panda có đang tấn công ko
    public bool Return_Panda_Attack()
    {
        return Check_pressed_space;
    }
   

    #region Chức năng di chuyển
    private void Movement()
    {
        #region Full phím nhấn trên máy tính
        bool Move_Left_direction_A = Input.GetKeyDown(KeyCode.A);
        bool Move_Right_direction_D = Input.GetKeyDown(KeyCode.D);
        bool Move_Top_direction_W = Input.GetKey(KeyCode.W);
        bool Move_Down_direction_S = Input.GetKey(KeyCode.S);

        float Move_Left_Right_direction = 0;// = Input.GetAxisRaw("Horizontal");
        float Move_Top_Down_direction = Input.GetAxisRaw("Vertical");
        #endregion


        bool Miss_Press = false;
        if (Miss_Press == true)
        {
            Move_Left_Right_direction = Input.GetAxisRaw("Horizontal");
            Miss_Press = false;

        } else if(Miss_Press == false && Input.GetAxisRaw("Horizontal") != 0 ){
            Miss_Press = true;

        }


        // Di chuyển Lên xuống
        if (Move_Top_direction_W  || Move_Top_Down_direction > 0 || Conect_ITMP.Get_InTouch_Panda_Top() == true) Panda_Move_Top();
        if (Move_Down_direction_S || Move_Top_Down_direction < 0 || Conect_ITMP.Get_InTouch_Panda_Down() ==true) Panda_Move_Down();

        // Di chuyển qua Trái phải
        if (Move_Left_direction_A || Move_Left_Right_direction < 0) Panda_Move_Left();
        if (Move_Right_direction_D || Move_Left_Right_direction > 0) Panda_Move_Right();
    }



    #region Hàm di chuyển Lên xuống
    public void Panda_Move_Top()
    {
        if(transform.position.y < 4.2f)
        {
            if (conversion_step == true) W_key_after_attacking = true;
            Conect_P_A_C.Set_Status(1);
            transform.position += new Vector3(0, speed * Time.deltaTime, 0); // Cho đối tượng di chuyển
            return;
        }
    }

    public void Panda_Move_Down()
    {
        if (_Path[0].y <= transform.position.y)
        {
            conversion_step = false; // Xóa biến lưu vừa tấn cống
            Conect_P_A_C.Set_Status(1);
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0); // Cho đối tượng di chuyển
            //if (Conect_P_A_C.Get_Status() == 8) return;
            return;
        }
    }
    #endregion


    #region Hàm di chuyển trái phái
    public void Panda_Move_Left()
    {
        if (location_tree_and_side - 2 >= 0) {
            conversion_step = false; // Xóa biến lưu vừa tấn cống
            location_tree_and_side -= 2;
            Last_Location = location_tree_and_side + 2;
            //Set animation
            Handle_moving_back_forth();
            transform.position = new Vector3(_Path[location_tree_and_side].x, transform.position.y, transform.position.z); // Cho đối tượng di chuyển
            Panda.Choose_Panda(Last_Location, location_tree_and_side);
            return;
        }
    }


    public void Panda_Move_Right()
    {
        if( location_tree_and_side + 2 < _Path.Count)
        {
            conversion_step = false; // Xóa biến lưu vừa tấn cống
            location_tree_and_side += 2;
            Last_Location = location_tree_and_side - 2;
            //Set animation
            Handle_moving_back_forth();
            transform.position = new Vector3(_Path[location_tree_and_side].x, transform.position.y, transform.position.z); // Cho đối tượng di chuyển
            Panda.Choose_Panda(Last_Location, location_tree_and_side);
            return;
        }
    }


    #endregion






    // Xử lý animate Panda di chuyển qua lại

    void Handle_moving_back_forth()
    {
        #region Anmation di chuyển qua lại trên 1 cây
        if (
            // Panda Right to Left
             Last_Location == 0 && location_tree_and_side == 2 || Last_Location == 4 && location_tree_and_side == 6 || Last_Location == 8 && location_tree_and_side == 10 ||
             // Panda Left to Right
             Last_Location == 2 && location_tree_and_side == 0 || Last_Location == 6 && location_tree_and_side == 4 || Last_Location == 10 && location_tree_and_side == 8
            )
        {
            //back_and_forth_function_is_active = true; 
            //Conect_P_A_C.Set_Status(5);
           // Conect_P_A_C.Set_Status(0);
            Debug.Log("Left or Right");
            //Thread.Sleep(5000);
            //back_and_forth_function_is_active = false;
        }
        #endregion

        #region Anmation di chuyển qua lại giữa 2 cây
        if (
             // Panda Right to Left
             Last_Location == 2 && location_tree_and_side == 4 || Last_Location == 6 && location_tree_and_side == 8 ||
             // Panda Left to Right
             Last_Location == 8 && location_tree_and_side == 6 || Last_Location == 4 && location_tree_and_side == 2
            )
        {
            //Conect_P_A_C.Set_Status(4);
        }
        #endregion


    }



    #endregion





}