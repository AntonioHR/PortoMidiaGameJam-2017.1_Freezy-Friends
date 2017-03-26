using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PlayerLoseState : PlayerActionState
{
    public PlayerLoseState(PlayerActionFSM fsm) : base(fsm)
    {
    }

    public override bool CanMove
    {
        get
        {
            return false;
        }
    }

    public override void ShootDown()
    {
    }

    public override void ShootUp()
    {
    }
}
