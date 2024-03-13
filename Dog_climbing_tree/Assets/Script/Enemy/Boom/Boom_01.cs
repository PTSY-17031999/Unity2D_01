using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom_01 : MonoBehaviour
{

    public enum Boom_Type
    {
        Type_1,
        Type_2
    }

    public List<GameObject> Boom_Right_left;
    public float _Speed = 1f; // Tốc độ di chuyển
    public Move_component _Move_Component; // Kết nối tới file class Move_component
    public int location_tree_and_side; // Vị trí cây
    Audio_Controller Conect_Class_Audio_Controller;
    public Animator animi;
    Game_Controller Conect_Game_cotroler;
    BoxCollider2D _BoxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        Conect_Class_Audio_Controller = FindObjectOfType<Audio_Controller>();
        Conect_Game_cotroler = FindObjectOfType<Game_Controller>();
        //_Move_Component = FindObjectOfType<Move_component>();

    }

    
    // Sét tham số cho Boom
    public void Set_Value(int location_tree_and_side, float _Speed, bool _Boom_Direction)
    {
        //Set loại Enemy trái or phải
        this.location_tree_and_side = location_tree_and_side;
        this._Speed = _Speed;
        //Debug.Log( "Tốc độ và vị trí cây tre" + _Speed + " and " + location_tree_and_side);
        _Move_Component.Set(_Speed, location_tree_and_side);

            Boom_Right_left[1].SetActive(_Boom_Direction);
            Boom_Right_left[0].SetActive(!_Boom_Direction);
       


    }

    public void Boom_Set_Animation()
    {
        Animator Boom_Animator_Right = Boom_Right_left[0].GetComponent<Animator>();
        Animator Boom_Animator_Left = Boom_Right_left[1].GetComponent<Animator>();

        if (Boom_Animator_Right != null && Boom_Animator_Left != null ) // Ensure that the Animator component is found
        {
            Boom_Animator_Right.SetBool("Boom_explodes", true);
            Boom_Animator_Left.SetBool("Boom_explodes", true);
        }
        else
        {
            Debug.LogWarning("Animator component not found on Boom_Right_left[0].");
        }
    }

}
