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
    }
    private void Update()
    {
    }

    public void Set_Status(float Blend)
    {
        animi.SetFloat("Blend", Blend);
    }

    public float Get_Status()
    {
        return animi.GetFloat("Status");
    }
}
