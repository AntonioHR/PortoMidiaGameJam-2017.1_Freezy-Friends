using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    [SerializeField]
    private string horAxis;
    [SerializeField]
    private string vertAxis;
    [SerializeField]
    private KeyCode fireKey;

    Player player;
    
    public Vector3 pointedDirection
    {
        get
        {
            var inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
            inputDirection = Quaternion.AngleAxis(45, Vector3.up) * inputDirection;

            return inputDirection;
        }
    }
    void Awake()
    {
        player = GetComponent<Player>();
    }
    void Update () {
        if (Input.GetKeyDown(fireKey))
            player.ShootDown();
        else if(Input.GetKeyUp(fireKey))
        {
            player.ShootUp();
        }
	}
}
