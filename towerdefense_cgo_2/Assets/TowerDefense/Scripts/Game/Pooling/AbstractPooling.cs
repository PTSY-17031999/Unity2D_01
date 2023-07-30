using UnityEngine;
using System.Collections;

public abstract class AbstractPooling : MonoBehaviour
{
    public static AbstractPooling Instance;
    private void Awake()
    {
        Instance = this;
    }

    public abstract GameObject GetObject();
}
