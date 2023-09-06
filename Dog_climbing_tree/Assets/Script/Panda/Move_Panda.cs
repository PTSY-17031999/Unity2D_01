using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Panda : MonoBehaviour
{
    
    float speed; // Tốc độ
    public Path _path;
    private List<Vector3> _Path = new List<Vector3>();
    int location_tree_and_side = 6;
    bool Check_pressed_space; //nút space được nhân khi tấn công
    public float Save_location_Y; // Lưu lại vị trí trước khi tấn công

    Panda Panda;

    private void Start()
    {
        Panda = FindObjectOfType<Panda>();
        Panda.Choose_Panda(-1, location_tree_and_side);
    }



    // Set than số cho Panda di chuyển
    public void Set_Star( float speed)
    {
        this.speed = speed; // Sét tốc độ bằng tốc độ Panda.
        _Path = _path.GetListPosition();
       
        transform.position = new Vector3(_Path[location_tree_and_side].x, transform.position.y, transform.position.z); // sét đối tượng về vị trí bắt đàu di chuyển
    }


    private void Update()
    {
        Attack();
        if (Check_pressed_space == false)
        { 
            Movement();
        }

    }


    // Chức năng tấn công
    bool conversion_step = false;
    bool W_key_after_attacking = false; // Lưu lại Phim W được nhắn sau khi tấn công
    private void Attack()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            Check_pressed_space = true;
            conversion_step = true;

            // Cho panda tấn công xuống
            if (_Path[0].y <= transform.position.y)
            {
                transform.position -= new Vector3(0, speed * Time.deltaTime, 0); // Cho đối tượng di chuyển
            }

        }
        else
        {
            Check_pressed_space = false;
        }

        //Luu lại vị trí cũ
        if(conversion_step != true) Save_location_Y = transform.position.y;


        // Cho panda về vị trí cũ nếu vừa tấn công
        if (W_key_after_attacking == true)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            Debug.Log("Veef laij vij tri cu");
            //kiểm tra xem panda đã về vị trí trước khi tấn công chưa
            if (transform.position.y >= Save_location_Y)
            {
                conversion_step = false;
                W_key_after_attacking = false;

            }
        }
    }

    // Chức năng di chuyển
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
        if ((Move_Top_direction_W || Move_Top_Down_direction > 0) && _Path[1].y >= transform.position.y && transform.position.y < 4.2f) 
        {
            Debug.Log("Click W");
            if(conversion_step == true)  W_key_after_attacking = true;
            transform.position += new Vector3(0, speed * Time.deltaTime, 0); // Cho đối tượng di chuyển
            Panda.Choose_Panda(true, false);
            return;
        }
         

        if ((Move_Down_direction_S || Move_Top_Down_direction <0) && _Path[0].y <= transform.position.y)
        {

            conversion_step = false; // Xóa biến lưu vừa tấn cống
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0); // Cho đối tượng di chuyển
            Panda.Choose_Panda(false, true);
            return;
        }


        // Di chuyển qua Trái phải
        if ((Move_Left_direction_A || Move_Left_Right_direction < 0) && location_tree_and_side - 2 >= 0 )
        {
            conversion_step = false; // Xóa biến lưu vừa tấn cống
            location_tree_and_side -= 2;
            transform.position = new Vector3(_Path[location_tree_and_side].x, transform.position.y, transform.position.z); // Cho đối tượng di chuyển
            Panda.Choose_Panda(location_tree_and_side + 2, location_tree_and_side);
            return;
        }
        if ((Move_Right_direction_D || Move_Left_Right_direction > 0) && location_tree_and_side + 2 < _Path.Count )
        {
            conversion_step = false; // Xóa biến lưu vừa tấn cống
            location_tree_and_side += 2;
            transform.position = new Vector3(_Path[location_tree_and_side].x, transform.position.y, transform.position.z); // Cho đối tượng di chuyển
            Panda.Choose_Panda(location_tree_and_side - 2, location_tree_and_side);
            return;
        }


        Panda.Choose_Panda(false, false);
    }


    // Trả về Panda có đang tấn công ko
    public bool Return_Panda_Attack()
    {
        return Check_pressed_space;
    }

   
}