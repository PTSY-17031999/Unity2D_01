using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private List<Vector2> _Path; // Lưu các vị trí các điểm di chuyển trên bản đồ
    private List<TileTower> _TileTowers; // Lưu của các tháp bảo vệ
    private Castle _Castle;
    private List<GameObject> _Abstacles; // Lưu các trướng ngại vật
}
