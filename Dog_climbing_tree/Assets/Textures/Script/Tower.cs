using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Tạo ra hai lựa chọn
public  enum ETower
{
    SingleTarget,
    MultiTarget,
}
public class Tower : MonoBehaviour
{
    public float Dmg; // Máu (Chỉ số sự sống)
    public float Cool_down; // Tốc độ chiến đấu
    public ETower TypeTower;
    public float RangeAttack; //Phạm vi chiến đấu
    public Transform PosShot; //Vị trí bắn

    public Attack_component Attack_Component;

    private void Start()
    {
        Attack_Component.Setup(Dmg, Cool_down, RangeAttack, PosShot);
    }


    // Vẽ một vòng tròn quanh vị trí bắn PosShot với khoảng cách RangeAttack
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PosShot.position, RangeAttack);
    }


}
