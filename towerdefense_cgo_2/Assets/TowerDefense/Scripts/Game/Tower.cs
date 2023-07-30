using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ETower
{ 
    SingleTarget,
    MultiTarget,
} 

public class Tower : MonoBehaviour
{
    public int levelCurrent = 1;
    public TowerSO towerSO;
    public TowerLevelUpSO towerData;
    public Transform ShotPos;

    public AttackComponent attackComponent;
    private void Start()
    {
        float dmg = towerSO.Dmg;
        float cooldown = towerSO.Cooldown;
        float rangeAttack = towerSO.RangeAttack;
        float speed = towerSO.SpeedProjectile;

        // Modify data depends on level
        for (int i = 0; i < levelCurrent; i++)
        {
            dmg += towerData.LevelUp[i].DmgIncrease;
            speed += towerData.LevelUp[i].SpeedIncrease;
        }


        attackComponent.Setup(dmg, cooldown, rangeAttack, speed, ShotPos.parent, this.towerSO.TowerType);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(ShotPos.position, towerSO.RangeAttack);
    }
}
