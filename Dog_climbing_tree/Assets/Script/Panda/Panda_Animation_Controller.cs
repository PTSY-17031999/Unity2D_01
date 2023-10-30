using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Panda_Animation_Controller : MonoBehaviour
{
    Animator animi;
    // Start is called before the first frame update
    void Start()
    {
        animi = GetComponent<Animator>();
        Debug.Log("Sy testing 01/10 22:50");
    }
    private void Update()
    {
    }

    public void Set_Status(float Blend)
    {
        animi.SetFloat("Blend", Blend);
        /* 
         * Nothing: 0
         * Right_To_Left hoặc ngược lại: 1
         * Attack: 2
         * Jump: 3
         * Death: 4
         * Down: 5
         * Up: 6
        */
    }

    public float Get_Status()
    {
        return animi.GetFloat("Status");
    }
}
