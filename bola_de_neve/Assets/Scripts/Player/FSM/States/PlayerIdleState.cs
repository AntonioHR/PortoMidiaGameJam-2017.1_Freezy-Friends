using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerIdleState : PlayerActionState
{
    public PlayerIdleState(PlayerActionFSM fsm) : base(fsm)
    {
    }

    public override bool CanMove
    {
        get
        {
            return true;
        }
    }

    public override void ShootUp()
    {
    }

    public override void ShootDown()
    {
        fsm.AdvanceTo(new PlayerAimState(fsm));
    }
}