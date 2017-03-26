using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Input/KeyConfig")]
public class PlayerInputKeyConfig:PlayerInputConfig
{
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode downKey;
    public KeyCode upKey;

    public KeyCode fireKey;
    public KeyCode dashKey;

    public override bool ShootDown
    {
        get
        {
            return Input.GetKeyDown(fireKey);
        }
    }

    public override bool ShootUp
    {
        get
        {
            return Input.GetKeyUp(fireKey);
        }
    }

    public override bool DashDown
    {
        get
        {
            return Input.GetKeyDown(dashKey);
        }
    }

    public override Vector3 Axis
    {
        get
        {
            return new Vector3(
                   CalculateAxis(leftKey, rightKey), 0,
                   CalculateAxis(downKey, upKey)).normalized;
        }
    }

    public static float CalculateAxis(KeyCode negative, KeyCode positive)
    {
        return (Input.GetKey(negative) ? -1 : 0) + (Input.GetKey(positive) ? 1 : 0);
    }
}
