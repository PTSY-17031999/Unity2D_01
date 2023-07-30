using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EEnemy
{
    Normal,
    Boss,
}

public class Enemy : MonoBehaviour
{
    public static int id = 0;
    public int Identity;
    public EnemySO enemySO;
    public MoveComponent movement;
    public HealthComponent health;

    private void Awake()
    {
        Identity = id++;
    }

    public void SetData(EnemySO data)
    {
        this.enemySO = data;
    }
    public void Init()
    {
        health.SetHp(enemySO.Hp);
        movement.Set(enemySO.Speed);
    }

    public void TakeDamage(float dmg)
    {
        health.TakeDamage(dmg);
    }

    public float GetDmg()
    {
        return enemySO.Dmg;
    }
}
