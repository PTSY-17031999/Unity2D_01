using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_bird : MonoBehaviour
{
    public Bird _Bird;
    // Start is called before the first frame update
    void Start()
    {

        //_Bird = FindObjectOfType<Bird>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_Bird && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("KHOANG TRANG");
            _Create_bird();
            Destroy(gameObject);
        }
            
        
    }

    void _Create_bird() {
        Instantiate(_Bird, transform.position, Quaternion.identity);
    }
}
