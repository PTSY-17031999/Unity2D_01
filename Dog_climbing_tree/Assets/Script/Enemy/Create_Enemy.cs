using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Enemy : MonoBehaviour
{
    int location_tree_and_side; //Vị trí xuất hiện Enemy
    public List<Enemy> Enemy_Type_Right; // Các loại Enemy hướng đi phải
    public List<Enemy> Enemy_Type_Left; // Các loại Enemy hướng đi trái

    int Enemy_Type; // Lựa chọn loại Enemy
    int Number_Enemy; //Số lượng Enemy mỗi lần sinh
    public float Time_Create_Enemy; // Thời gian tạo ra Enemi
    float Miss_Time = 0;



    // Update is called once per frame
    void Update()
    {
        Miss_Time += Time.deltaTime;
        if (Time_Create_Enemy >= Miss_Time)
        {
            _Create_Enemy();
            Miss_Time = 0;
        }
       


    }

    private void _Create_Enemy()
    {
        Number_Enemy = Random.Range(1, 5);
        Enemy_Type = Random.Range(0, Enemy_Type_Right.Count - 1);
        location_tree_and_side = Random.Range(0, 5);

        for (int i = 0; i <= Number_Enemy; i++)
        {
            WaitForMoving();
        }

    }
    void Create()
    { // Sinh ra các Enemy nếu Enemy phía trái
        if (location_tree_and_side % 2 == 0)
        {
            Enemy enemy = Instantiate(Enemy_Type_Left[Enemy_Type]);
            enemy.Set_Value(location_tree_and_side);
            Debug.Log(" Create Enemy left");
           
        }

        // Sinh ra các Enemy nếu Enemy phía phải
        if (location_tree_and_side % 2 != 0)
        {
            Enemy enemy = Instantiate(Enemy_Type_Right[Enemy_Type]);

            enemy.Set_Value(location_tree_and_side);
            Debug.Log(" Create Enemy Right");
        }
    }




    private IEnumerator WaitForMoving()
    {
        yield return new WaitForSeconds(0.2f); // Chờ 2s mới dược chạy hàm Start_Move
        Create();
    }
}
