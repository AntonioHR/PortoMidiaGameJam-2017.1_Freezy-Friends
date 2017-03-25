using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Shoots bullets
/// </summary>
public class Cannon : MonoBehaviour {
    public float offset;

    public void Shoot(Bullet bullet)
    {
        Vector3 shootVec = transform.TransformVector(Vector3.forward * offset);
        var obj = bullet.Create();
        obj.transform.position = transform.position + shootVec * offset;
        obj.transform.rotation = transform.rotation;

        var rb = obj.GetComponent<Rigidbody>().velocity = bullet.shootSpeed * shootVec;
        
    }

    void OnDrawGizmos()
    {
        Vector3 shootVec = transform.TransformVector(Vector3.forward * offset);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, shootVec);
        Gizmos.DrawSphere(transform.position + shootVec, .1f);
    }
}
