using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Cost;

    private void Awake()
    {
        Instance = this;
    }
}