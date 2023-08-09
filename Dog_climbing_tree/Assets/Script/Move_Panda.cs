using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Panda : MonoBehaviour
{
    public float speed = 8f; // Tốc độ
    public Path _path;
    private List<Vector3> _Path = new List<Vector3>();
    int _Location;




    private void Start()
    {
        //this.speed = speed; // Sét tốc độ bằng tốc độ Enemy.
        speed = 5f;
        _Path = _path.GetListPosition();
        _Location = 8; // Sét vị trí hiện tại của Panda 
        transform.position = new Vector3(_Path[_Location].x, transform.position.y, transform.position.z); // sét đối tượng về vị trí bắt đàu di chuyển
    }


    private void Update()
    {

        Movement();



    }

    private void Movement()
    {
        bool Move_Left_direction = Input.GetKeyUp(KeyCode.A);
        bool Move_Right_direction = Input.GetKeyUp(KeyCode.D);
        bool Move_Top_direction = Input.GetKey(KeyCode.W);
        bool Move_Down_direction = Input.GetKey(KeyCode.S);

        // Di chuyển Lên xuống
        if (Move_Top_direction && _Path[2].y <= transform.position.y) {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0); // Cho đối tượng di chuyển
        }
        if (Move_Down_direction && _Path[1].y >= transform.position.y)
        {
            _Location += 2;
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0); // Cho đối tượng di chuyển
        }


        // Di chuyển qua Trái phải
        if (Move_Left_direction && _Location >= 0)
        {
            _Location -= 2;
            transform.position = new Vector3(_Path[_Location].x, transform.position.y, transform.position.z); // Cho đối tượng di chuyển
        }
        if (Move_Right_direction && _Location <= _Path.Count)
        {
            _Location += 2;
            transform.position = new Vector3(_Path[_Location].x, transform.position.y, transform.position.z); // Cho đối tượng di chuyển
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
}