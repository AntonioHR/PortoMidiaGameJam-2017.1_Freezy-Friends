using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Input/JoystickConfig")]
public class PlayerInputJoystickConfig: PlayerInputConfig
{
    //public int joystickNumber;

    public string joystickFireButton;
    public string joystickDashButton;
    public string veticalAxis;
    public string horizontalAxis;

    public override bool ShootDown
    {
        get
        {
            return Input.GetButtonDown(joystickFireButton);
        }
    }

    public override bool ShootUp
    {
        get
        {
            return Input.GetButtonUp(joystickFireButton);
        }
    }

    public override bool DashDown
    {
        get
        {
            return Input.GetButtonDown(joystickDashButton);
        }
    }

    public override Vector3 Axis
    {
        get
        {
            return new Vector3( Input.GetAxis(horizontalAxis), 0, Input.GetAxis(veticalAxis));
        }
    }
}
