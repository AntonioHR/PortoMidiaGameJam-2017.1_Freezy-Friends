using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PlayerDeadState : PlayerActionState
{
    public PlayerDeadState(PlayerActionFSM fsm) : base(fsm)
    {
    }

    public override bool CanMove
    {
        get
        {
            return false;
        }
    }
    public override bool Dead
    {
        get
        {
            return true;
        }
    }
    public override void OnEnter()
    {
        fsm.player.Die();
    }
    public override void Update()
    {
        if(fsm.player.gameObject.activeSelf)
            fsm.AdvanceTo(new PlayerIdleState(fsm));
    }
    public override void ShootDown()
    {
    }

    public override void ShootUp()
    {
    }
}
