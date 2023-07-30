using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// 2 lựa chọn tấn công 1 mục tiêu hay nhiều mục tiêu
public enum EAttack
{
    SingleTarget,
    MultiTarget,
}
public class Attack_component : MonoBehaviour
{

    public float Dmg; // Mấu (Chỉ số chiến đáu)
    public float Cool_down; // Tốc độ chiến đấu
    public float RangeAttack; // Biến kiểm tra có mục tiêu nào nằm trong phạm vi chiến đấu ko
    public EAttack AttackType; // Lựa chọn đánh 1 mục tiêu hay nhiều mục tiêu
    public GameObject ProjectileType; // Loại đạn
    private Transform PosShot; //Vị trí bắn
    public float TimeShoot; // Thời gian bắn
    private float TimeShoot_Curent = 0;
    private Transform enemy; // Vị trí Enemy nằm trong phạm vi bị bắn

    // Set up thông số ban đầu
    public void Setup(float Dmg, float Cool_down, float RangeAttack, Transform PosShot)
    {
        this.Dmg = Dmg;
        this.Cool_down = Cool_down;
        this.RangeAttack = RangeAttack;
        this.PosShot = PosShot;
    }



    // Sét vị trí của anemy cho Tower bắn
    public void SetTarget(Transform target)
    {
        Debug.Log("NG1");
        this.enemy = target;
    }
    private void Update()
    {
        if (enemy == null) return; // nếu ko có enemy nào nằm trong phạm vi bắn

        TimeShoot_Curent += Time.deltaTime;
        if(TimeShoot_Curent >= TimeShoot)
        {
            SpawnProjectile();
            TimeShoot_Curent = 0;
        }
        
    }

    //Tạo ra mũi tên với vị trí PosShot
    private void SpawnProjectile()
    {
        var projectile = Instantiate(ProjectileType);
        projectile.transform.position = PosShot.position;

        //Tính ra vetor từ Vị trí bắn của Tower đén Enemy
        Vector3 direction = (enemy.position - PosShot.position).normalized;
        // Tính góc giữ Vị trí bắn của Tower và Enemy
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Chuyển từ góc rad sang độ Mathf.Rad2Deg
        projectile.transform.eulerAngles = new Vector3(0, 0, angle);         // Sét góc xoay cho mũi tên


    }

}
