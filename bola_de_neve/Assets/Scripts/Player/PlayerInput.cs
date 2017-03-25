using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    //[SerializeField]
    //private string horAxis;
    //[SerializeField]
    //private string vertAxis;
    public PlayerKeyConfig config;

    Player player;
    
    public Vector3 pointedDirection
    {
        get
        {
            //var inputDirection = new Vector3(Input.GetAxis(horAxis), 0, Input.GetAxis(vertAxis)).normalized;
            var inputDirection = new Vector3(
                CalculateAxis(config.leftKey, config.rightKey), 0, 
                CalculateAxis(config.downKey, config.upKey)).normalized;
            inputDirection = Quaternion.AngleAxis(45, Vector3.up) * inputDirection;

            return inputDirection;
        }
    }
    void Awake()
    {
        player = GetComponent<Player>();
    }
    void Update () {
        if (Input.GetKeyDown(config.fireKey))
            player.ShootDown();
        else if(Input.GetKeyUp(config.fireKey))
        {
            player.ShootUp();
        }
	}
    float CalculateAxis(KeyCode negative, KeyCode positive)
    {
        return (Input.GetKey(negative) ? -1 : 0) + (Input.GetKey(positive) ? 1 : 0);
    }
}
