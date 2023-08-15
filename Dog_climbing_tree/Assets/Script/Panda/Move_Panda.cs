using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Panda : MonoBehaviour
{
    float speed; // Tốc độ
    public Path _path;
    private List<Vector3> _Path = new List<Vector3>();
    int location_tree_and_side;
    bool Check_pressed_space; //nút space được nhân khi tấn công
    public float Save_location_Y; // Lưu lại vị trí trước khi tấn công



    // Set than số cho Panda di chuyển
    public void Set_Star( float speed , int location_tree_and_side)
    {
        this.speed = speed; // Sét tốc độ bằng tốc độ Panda.
        this.location_tree_and_side = location_tree_and_side; // Sét vị trí hiện tại của Panda 
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
            // Cho panda về vị trí cũ
            if(conversion_step == true)
            {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
                //kiểm tra xem panda đã về vị trí trước khi tấn công chưa
                if(transform.position.y >= Save_location_Y)
                {
                    conversion_step = false;
                }
                    
                return;
            }
            Save_location_Y = transform.position.y;
        }
 
    }

    // Chức năng di chuyển
    private void Movement()
    {
        bool Move_Left_direction = Input.GetKeyDown(KeyCode.A);
        bool Move_Right_direction = Input.GetKeyDown(KeyCode.D);
        bool Move_Top_direction = Input.GetKey(KeyCode.W);
        bool Move_Down_direction = Input.GetKey(KeyCode.S);

        // Di chuyển Lên xuống
        if (Move_Top_direction && _Path[1].y >= transform.position.y && transform.position.y < 4.2f) {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0); // Cho đối tượng di chuyển
        }
        if (Move_Down_direction && _Path[0].y <= transform.position.y)
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0); // Cho đối tượng di chuyển
        }


        // Di chuyển qua Trái phải
        if (Move_Left_direction && location_tree_and_side - 2 >= 0 )
        {
            location_tree_and_side -= 2;
            transform.position = new Vector3(_Path[location_tree_and_side].x, transform.position.y, transform.position.z); // Cho đối tượng di chuyển
        }
        if (Move_Right_direction && location_tree_and_side + 2 < _Path.Count )
        {
            location_tree_and_side += 2;
            transform.position = new Vector3(_Path[location_tree_and_side].x, transform.position.y, transform.position.z); // Cho đối tượng di chuyển
        }



        /*
        Vector3 direction = _endPos - _startPos; // Lấy hướng di chuyển
        direction.Normalize(); // Chuển nó thành - 1 hoặc 1
        transform.position += direction * speed * Time.deltaTime; // Cho đối tượng di chuyển

        if (Vector3.Distance(transform.position, _endPos) <= 0.05f) // Nếu vị trí hiện tại đến điểm cuối < = gần  đổi hướng
        {
            Destroy(gameObject);
        }*/
    }

    // Trả về Panda có đang tấn công ko
    public bool Return_Panda_Attack()
    {
        return Check_pressed_space;
    }
}