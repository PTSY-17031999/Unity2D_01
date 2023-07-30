///*
// TOWER DEFENSE ??
//- Thủ thành: bảo vệ lâu đài khỏi quái vật tấn công bằng các tower
//- Các thành phần chính trong Gameplay:
//	+ Lâu đài chính: Hp
//	+ Map: Đường đi quái, các vị trí đặt Tower
//	+ Tower: Nâng cấp, mua được, bán được, các loại Tower
//	+ Enemy: Chỉ số (atk, def,..), các loại quái vật
//	+ Abilities: ở Tower và Enemy
//*/

///*
//- Thiết kế Gameplay
//*Lâu đài
//- Hp	   - float
//=> C#
//*/
//using System.Collections.Generic;
//using UnityEngine;

//class Castle 
//{
//	private float Hp;
//	public void Damage(float damage)
//	{
//		Hp -= damage;
//	}
//}

///*
//*Tower
//- position			- Vector2
//- damageAttack		- float
//- range				- float
//- level				- int
//- towerType			- enum
//- attackSpeed			- float
// */
//public enum TowerType
//{
//	SingleTarget,
//	MultiTarget
//}
//public class Tower
//{
//	private Vector2 position;
//	private float damageAttack;
//	private float range;
//	private int level;
//	private TowerType towerType;
//	private float attackSpeed;
//}

///*
//*Enemy
//- hp			- float
//- speed			- float
//- def			- float
//- enemyType		- enum
//- attackDamage	- float
//- idWave		- int
// */
//public enum EnemyType
//{
//	Walk,
//	Fly
//}
//public class Enemy
//{
//	private float hp;
//	private float speed;
//	private float def;
//	private float attackDmg;
//	private int idWave;
//	private EnemyType enemyType;
//}

///*
//Map
//-path		- List<position>
//-tileTower	- List<TileTower>
//-castle		- Castle
//-obstacles	- List<GameObject>
//*/

//public class TileTower
//{
//	private bool isAvailable;
//	private Tower towerCurrent;
//}

//public class Map
//{
//	private List<Vector2> path;
//	private List<TileTower> tileTowers;
//	private Castle castle;
//	private List<GameObject> obstacles;
//}