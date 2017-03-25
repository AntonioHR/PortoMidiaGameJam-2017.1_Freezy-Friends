using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    public PlayerInputConfig config;

    Player player;
    
    public Vector3 pointedDirection
    {
        get { return Quaternion.AngleAxis(45, Vector3.up) * config.Axis; }
    }
    void Awake()
    {
        player = GetComponent<Player>();
    }
    void Update () {
        if (config.ShootDown)
            player.ShootDown();
        else if(config.ShootUp)
            player.ShootUp();
	}
}
