using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Shoots bullets
/// </summary>
public class Cannon : MonoBehaviour {
    public float offset;

    Quaternion lockedRot;
    bool lockRot;
    public bool Lock
    {
        get
        {
            return lockRot;
        }
        set
        {
            if (value)
            {
                lockedRot = transform.rotation;
            } else
            {
                transform.localRotation = Quaternion.identity;
            }
            lockRot = value;
        }
    }

    [Range(0, 90)]
    public float inclineAngle;

    public Player owner;
    public Vector3 ShootVec
    {
        get {
            return transform.TransformVector(
                Quaternion.AngleAxis(inclineAngle, Vector3.left) * Vector3.forward * offset);
        }
    }
    public void LateUpdate()
    {
        if(lockRot)
        {
            transform.rotation = lockedRot;
        }
    }
    public GameObject Shoot(BulletData bulletData)
    {
        Vector3 shootVec = ShootVec;
        var obj = bulletData.Create();
        obj.transform.position = transform.position + shootVec * offset;
        obj.transform.rotation = transform.rotation;
        var bullet = obj.GetComponent<Bullet>();

        bullet.body.velocity = bulletData.shootSpeed * shootVec;
        bullet.SetOwner(owner);

        return obj;
    }

    void OnDrawGizmos()
    {
        Vector3 shootVec = ShootVec;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, shootVec);
        Gizmos.DrawSphere(transform.position + shootVec, .1f);
    }
}
