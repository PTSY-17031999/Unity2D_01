using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Horizontal,
    Vertial
}

public class CameraMoveByFinger : MonoBehaviour
{
    public Direction direction = Direction.Vertial;
    public Vector3 firstPoint;
    public Vector3 secondPoint;
    public float speedMove;

    public Transform Point_on_map; 
    public Transform Point_up_map;
    public Transform Point_on_camera;
    public Transform Point_up_camera;


    // Update is called once per frame
    void Update()
    {
        Processing();
    }

    public void Processing()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPoint = Input.mousePosition;
        }


        if (Input.GetMouseButton(0))
        {
            secondPoint = Input.mousePosition;

            var direction = secondPoint - firstPoint;
            direction.Normalize();

            if (this.direction == Direction.Horizontal)
            {
                direction.y = 0; // (x, 0, 0) v3.left
            }
            else
            {
                direction.x = 0;
            }

            direction.z = 0;
            if ((transform.position + new Vector3(0f, 3.8f, 0f)).y >= Point_on_map.position.y && direction.y < 0 || (transform.position + new Vector3(0f, -3.8f, 0f)).y <= Point_up_map.position.y && direction.y > 0)
            {
                Debug.Log("Dddd"); return;
            }
            transform.position += -direction * Time.deltaTime * speedMove;
        }
    }

    void check_camera_out_map()
    {

        if ((transform.position + new Vector3(0f, 3.8f, 0f)).y >= Point_on_map.position.y && direction > 0 || (transform.position + new Vector3(0f, -3.8f, 0f)).y <= Point_up_map.position.y && direction > 0)
        {
            Debug.Log("Dddd"); return;
        }
        
    }
}
