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
    public float TimeSet_value = 40; // Thời gian tạo ra Enemi
    float Miss_Time = 0;
    bool Miss = false;



    // Update is called once per frame
    void Update()
    {
        
        if (Miss != true)
        {
            Set_value();
            Miss = true;
        }

        Miss_Time += Time.deltaTime;

        if( Miss_Time >= TimeSet_value && Number_Enemy > 0)
        {
            _Create_Enemy();
            Number_Enemy--;
            Miss_Time = 0;
            if (Number_Enemy <= 0) {
                Miss = false;
            }
        }




    }


    // Set tham số cho enemy trước khi sinh ra
    private void Set_value()
    {
        Number_Enemy = Random.Range(1, 6);
        Enemy_Type = Random.Range(0, Enemy_Type_Right.Count );
        Debug.Log("Test enemy" + Enemy_Type_Right.Count);
        Debug.Log("Test enemy type" + Enemy_Type);
        do
        {
            location_tree_and_side = Random.Range(0, 11);

        } while (location_tree_and_side % 2 != 0);

    }

    private void _Create_Enemy()
    {
        Enemy enemy;

        // Sinh ra các Enemy nếu Enemy phía trái
        if (location_tree_and_side == 0 || location_tree_and_side == 4 || location_tree_and_side == 8)
        {
            enemy = Instantiate(Enemy_Type_Left[Enemy_Type]);
            enemy.Set_Value(location_tree_and_side, 1f); 
            
        }

        // Sinh ra các Enemy nếu Enemy phía phải
        if (location_tree_and_side == 2 || location_tree_and_side == 6 || location_tree_and_side == 10)
        {
            enemy = Instantiate(Enemy_Type_Right[Enemy_Type]);
            enemy.Set_Value(location_tree_and_side, 1f);
           
        }
    }



    //StartCoroutine(WaitForMoving());
    /* private IEnumerator WaitForMoving()
     {
         yield return new WaitForSeconds(0.2f); // Chờ 2s mới dược chạy
         Create();
     } */

}
