using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Dmg;
    public MoveForwardComponent MoveForward;
    public int IdentityId; // định danh của tảget
    public Vector3 targetPos;
    public ETower towerType;
    public Animator animator;

    public bool isReached = false;

    public void SetTowerType(ETower tower)
    {
        this.towerType = tower;
    }
    public void SetIdentity(int id)
    {
        this.IdentityId = id;
    }

    public void SetTargetPos(Vector3 pos)
    {
        targetPos = pos;
    }

    private void Update()
    {
        if (isReached) return;
        if (Vector2.Distance(transform.position, targetPos) < 0.05f)
        {
            isReached = true;
            StartCoroutine(WaitingForDestroy());

        }
    }
    private IEnumerator WaitingForDestroy()
    {
        animator.SetTrigger("trigger");
        MoveForward.Stop();
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        isReached = false;
    }

    public void SetSpeed(float speed)
    {
        this.MoveForward.SetSpeed(speed);
    }
    public void SetDamage(float dmg)
    {
        this.Dmg = dmg;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // phat hien va cham voi quai vat
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                if (towerType == ETower.SingleTarget)
                {
                    if (enemy.Identity == this.IdentityId)
                    {
                        enemy.TakeDamage(this.Dmg);
                        //Destroy(gameObject);
                        //gameObject.SetActive(false);
                        isReached = true;
                        StartCoroutine(WaitingForDestroy());
                    }
                }
                else
                {
                    enemy.TakeDamage(this.Dmg);
                    //Destroy(gameObject);
                    //gameObject.SetActive(false);
                    isReached = true;
                    StartCoroutine(WaitingForDestroy());
                }
            }
        }
    }
}
