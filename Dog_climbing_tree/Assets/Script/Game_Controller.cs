using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{


    public bool Is_Over_game = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set_Over_Game(bool is_over)
    {
        Is_Over_game = is_over;
        Debug.Log("Game Over");
    }
    public bool Get_Over_Game()
    {
        return Is_Over_game;
    }
}
