using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu()]
public class BulletData : ScriptableObject {

    [SerializeField]
    private GameObject prefab;
    public float shootSpeed;

    public GameObject Create()
    {

        return Instantiate(prefab);
    }
}
