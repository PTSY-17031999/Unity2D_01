using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Transform> ListPositions;

    public List<Vector3> GetListPosition()
    {
        List<Vector3> position = new List<Vector3>();
        for (int i = 0; i < ListPositions.Count; i++)
        {
            position.Add(ListPositions[i].position);
        }
        return position;
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < ListPositions.Count - 1; i++)
        {
            Gizmos.DrawLine(ListPositions[i].position, ListPositions[i + 1].position);
        }
    }
}
