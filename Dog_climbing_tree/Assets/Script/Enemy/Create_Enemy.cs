using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Enemy : MonoBehaviour
{
    [SerializeField] int location_tree_and_side; //Vị trí xuất hiện Enemy
    public List<Enemy> Enemy_Type_Right; // Các loại Enemy hướng đi phải
    public List<Enemy> Enemy_Type_Left; // Các loại Enemy hướng đi trái

    [SerializeField] private int Enemy_Type; // Lựa chọn loại Enemy
    [SerializeField] private int Quantity_Enemy; //Số lượng Enemy mỗi lần sinh
    float Miss_Time = 0;
    bool Miss = false;
    Game_Controller Conect_Game_Controler;


    #region Level
    public float Speed_Enemy = 1f; // Vận tốc Enemy
    public int Max_Quantity_Enemy = 6; // Số lượng Enemy lớn nhất mỗi lần tạo
    public float TimeSet_value = 0.85f; // Thời gian tạo ra Enemi
    #endregion

    private void Start()
    {
        Conect_Game_Controler = FindObjectOfType<Game_Controller>();

    }


    bool Set_Pause_Create_This = false;
    // Update is called once per frame
    void Update()
    {
        if (Conect_Game_Controler.Get_Pause_Game() == true || Set_Pause_Create_This == true)
        {
            return;
        }

        if (Miss != true)
        {
            Set_value();
            Miss = true;
        }

        Miss_Time += Time.deltaTime;

        if( Miss_Time >= TimeSet_value && Quantity_Enemy > 0)
        {
            _Create_Enemy();
            Quantity_Enemy--;
            Miss_Time = 0;
            if (Quantity_Enemy <= 0) {
                Miss = false;
            }
        }




    }


    // Set tham số cho enemy trước khi sinh ra
    private void Set_value()
    {
        Quantity_Enemy = Random.Range(1, Max_Quantity_Enemy);
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
            enemy = Instantiate(Enemy_Type_Right[Enemy_Type]);
            enemy.Set_Value(location_tree_and_side, Speed_Enemy, true); 
            
        }

        // Sinh ra các Enemy nếu Enemy phía phải
        if (location_tree_and_side == 2 || location_tree_and_side == 6 || location_tree_and_side == 10)
        {
            enemy = Instantiate(Enemy_Type_Right[Enemy_Type]);
            enemy.Set_Value(location_tree_and_side, Speed_Enemy, false);
           
        }
    }



    
      
    
    private IEnumerator WaitForMoving()
     {
         yield return new WaitForSeconds(2f); // Chờ 2s mới dược chạy
        Set_Pause_Create_This = false;
     }

    public void Return_Value_Level(int Level)
    {
        Set_Pause_Create_This = true;
        switch (Level){ 
            case 1:
                Speed_Enemy = 1f; 
                TimeSet_value = 0.85f;
                break;
            case 2:
                Speed_Enemy = 1.5f;
                TimeSet_value = 0.6f;
                break;
            case 3:
                Speed_Enemy = 2f;
                TimeSet_value = 0.4f;
                break;
            case 4:
                Speed_Enemy = 2.5f;
                TimeSet_value = 0.35f;
                break;
            case 5:
                Speed_Enemy = 3f;
                TimeSet_value = 0.3f;
                break;
            case 6:
                Speed_Enemy = 3.5f;
                TimeSet_value = 0.25f;
                break;
            case 7:
                Speed_Enemy = 4f;
                break;
            case 8:
                Speed_Enemy = 4.5f;
                TimeSet_value = 0.17f;
                break;
            case 9:
                Speed_Enemy = 5f;
                TimeSet_value = 0.15f;
                break;
        }
        StartCoroutine(WaitForMoving());

    }
}
