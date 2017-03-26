using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerAimState : PlayerActionState
{
    public PlayerAimState(PlayerActionFSM fsm) : base(fsm)
    {
    }

    public override bool CanMove
    {
        get
        {
            return true;
        }
    }

    public override void Update()
    {
    }

    public override void ShootDown()
    {
    }
    public override void ShootUp()
    {
        fsm.player.cannon.Shoot(fsm.player.defaultBullet);

        fsm.AdvanceTo(new PlayerIdleState(fsm));
    }
}
