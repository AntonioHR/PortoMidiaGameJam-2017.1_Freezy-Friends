using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Bullet : ScriptableObject {

    [SerializeField]
    private GameObject prefab;
    public float shootSpeed;

    public GameObject Create()
    {

        return Instantiate(prefab);
    }
}
