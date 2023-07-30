using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TowerLevelUpSO : ScriptableObject
{
    public List<TowerLevelDetail> LevelUp = new List<TowerLevelDetail>();
}

[System.Serializable]
public class TowerLevelDetail
{
    public float DmgIncrease;
    public float SpeedIncrease;
}