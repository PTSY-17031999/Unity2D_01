using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TowerSO : ScriptableObject
{
    public float Dmg;
    public float Cooldown;
    public ETower TowerType;
    public float RangeAttack;
    public float SpeedProjectile;
}
