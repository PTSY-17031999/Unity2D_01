using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _Speed = 1f; // Tốc độ di chuyển
    float _Def;
    float _AttackDmg;
    int _IdWave;
    public Move_component _Move_Component; // Kết nối tới file class Move_component
    public int location_tree_and_side = 2;// Vị trí cây
    Audio_Controller Conect_Class_Audio_Controller;
    public Animator animi;
    Game_Controller Conect_Game_cotroler;
    BoxCollider2D _BoxCollider2D;



    private void Start()
    {
        Conect_Class_Audio_Controller = FindObjectOfType<Audio_Controller>();
        Conect_Game_cotroler = FindObjectOfType<Game_Controller>();
        _BoxCollider2D = FindObjectOfType<BoxCollider2D>();
       
    }


    // Sét tham số cho Enemy
    public void Set_Value( int location_tree_and_side, float _Speed)
    {
        //Set loại Enemy trái or phải
        this.location_tree_and_side = location_tree_and_side;
        this._Speed = _Speed;
        _Move_Component.Set(_Speed, location_tree_and_side);

    }
   

   
    // Xử lý khi Enemy Die
    public void Handling_Enemy_Die()
    {
        Conect_Game_cotroler.Set_Score(); // Tăng điểm cho Enemy
        Conect_Class_Audio_Controller.Play_Enemy_Dead_sound();
        animi.SetBool("Move_Death", true);
        _BoxCollider2D.enabled = false;
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Debug.Log("Enemy Die");

    }

    public void Stop_IsTrigger(bool istrigger)
    {
        gameObject.transform.GetComponent<Collider2D>().isTrigger = istrigger;
    }
}
 