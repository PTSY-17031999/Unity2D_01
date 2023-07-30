using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Arrow Pooling is pool for arrows
/// </summary>
public class ArrowPooling : AbstractPooling
{
    public List<Projectile> arrowPool = new List<Projectile>();
    public Projectile projectilePrefab;

    public override GameObject GetObject()
    {
        return GetArrow().gameObject;
    }

    //Take out arrow
    private Projectile GetArrow()
    {
        Projectile target = null;

        foreach (Projectile proj in arrowPool)
        {
            if (proj.gameObject.activeSelf == false)
            {
                target = proj;
                break;
            }
        }

        if (target == null)
        {
            target = CreateArrow();
        }

        return target;
    }

    //Create arrow
    private Projectile CreateArrow()
    {
        Projectile proj = Instantiate(projectilePrefab, transform);
        arrowPool.Add(proj);
        return proj;
    }
}
