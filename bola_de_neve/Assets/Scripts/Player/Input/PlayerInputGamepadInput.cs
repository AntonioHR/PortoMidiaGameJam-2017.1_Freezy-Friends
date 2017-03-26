using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using GamepadInput;

[CreateAssetMenu(menuName = "Player/Input/GamepadInput")]
public class PlayerInputGamepadInput: PlayerInputConfig
{
    public GamePad.Index idx;
    public GamePad.Button shootButton;
    public GamePad.Button dashButton;
    public GamePad.Button dashButtonAlternate;

    PlayerInputKeyConfig alternate;

    public override bool ShootDown
    {
        get
        {
            return GamePad.GetButtonDown(shootButton, idx);
        }
    }

    public override bool ShootUp
    {
        get
        {
            return GamePad.GetButtonUp(shootButton, idx);
        }
    }

    public override bool DashDown
    {
        get
        {
            return GamePad.GetButtonDown(dashButton, idx) || GamePad.GetButtonDown(dashButtonAlternate, idx);
        }
    }

    public override Vector3 Axis
    {
        get
        {
            GamepadState state = GamePad.GetState(idx);
            var v1 = state.LeftStickAxis;
            return new Vector3(v1.x, 0, v1.y);
        }
    }
}
