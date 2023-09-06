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
        animi.SetInteger("Status", 4 );
    }
    private void Update()
    {
       // animi.SetInteger("Status", 5);
    }

    public void Set_Status(int Status)
    {
        /* 
         * "Up" = 0
         * "Down" = 1
         * "Death" = 2
         * "Attack" = 3
         * "Jump" = 4
         * "Nothing" = 5
         * "Net_Panda" = 6
        */
        animi.SetInteger("Status", Status);
    }
}
