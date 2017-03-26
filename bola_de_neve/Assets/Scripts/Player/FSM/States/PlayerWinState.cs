using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PlayerWinState : PlayerActionState
{
    public PlayerWinState(PlayerActionFSM fsm) : base(fsm)
    {
    }

    public override bool CanMove
    {
        get
        {
            return false;
        }
    }

    public override void OnEnter()
    {
        fsm.player.audio.PlayWin();
    }
    public override void ShootDown()
    {
    }

    public override void ShootUp()
    {
    }
}
