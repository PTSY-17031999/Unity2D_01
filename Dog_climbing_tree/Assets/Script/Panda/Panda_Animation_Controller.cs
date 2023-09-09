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
        animi.SetInteger("Status", 0 );
    }
    private void Update()
    {
      
    }

    public void Set_Status(int Status)
    {
        /* 
         * Nothing: 0
         * Right_To_Left hoặc ngược lại: 1
         * Attack: 2
         * Jump: 3
         * Death: 4
         * Down: 5
         * Up: 6
        */
        animi.SetInteger("Status", Status);
    }

    public int Get_Status()
    {
        return animi.GetInteger("Status");
    }
}
