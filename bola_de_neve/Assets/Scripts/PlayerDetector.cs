using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour {
    List<Player> ignored;

    public List<Player> current;

    private void Awake()
    {
        current = new List<Player>();
        ignored = new List<Player>();
    }

    public Player Closest
    {
        get
        {
            Player closest = null;
            var maxD = float.PositiveInfinity;
            foreach (Player player in current)
            {
                var d = (transform.position - player.transform.position).sqrMagnitude;
                if (d < maxD)
                {
                    closest = player;
                    maxD = d;
                }
            }
            return closest;
        }
    }

    public float EaseFactor(Player closest)
    {
        float maxDist = GetComponent<SphereCollider>().radius;

        return (closest.transform.position - transform.position).magnitude / maxDist;
    }

    void OnTriggerEnter(Collider other)
    {
        var player = Player.GetFromCollider(other);
        if (player != null && !ignored.Contains(player))
        {
            current.Add(player);
        }
    }
    void OnTriggerExit(Collider other)
    {
        var player = Player.GetFromCollider(other);
        if (player != null)
        {
            current.Remove(player);
        }
    }
    
    public void Ignore(Player player)
    {
        ignored.Add(player);
        current.Remove(player);
    }
}
