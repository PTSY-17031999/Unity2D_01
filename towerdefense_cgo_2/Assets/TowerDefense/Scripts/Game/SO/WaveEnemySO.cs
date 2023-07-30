using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WaveEnemySO : ScriptableObject
{
    public List<WaveEnemy> waves = new List<WaveEnemy>();
}

[System.Serializable]
public class WaveEnemy
{
    public int Amount;
    public float TimeSpawn;
}