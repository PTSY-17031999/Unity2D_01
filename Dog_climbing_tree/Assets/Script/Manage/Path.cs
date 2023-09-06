using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Transform> ListPositions; // List các điểm 

    // Đưa các điểm vào 1 list transform, và add vào một list vecter 3
    public List<Vector3> GetListPosition()
    {
        List<Vector3> Position = new List<Vector3>();
        for(int i = 0; i <= ListPositions.Count-1; i++)
        {
            Position.Add(ListPositions[i].position);
        }
               return Position;
    }


    // Vẽ các đường line từ các điểm qua nhau trên màn hình Seence
    private void OnDrawGizmos()
    {
        for (int i = 0; i < ListPositions.Count-1; i+=2)
        {
            if(i >= ListPositions.Count) { break; } // Vẽ tới điểm cuối thì dừng lại
            Gizmos.color = Color.red; // Làm line có mầu đỏ
            Gizmos.DrawLine(ListPositions[i].position, ListPositions[i + 1].position);
           

        }
            
    }
}
