﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PlayerShootState : PlayerActionState
{
    public PlayerShootState(PlayerActionFSM fsm) : base(fsm)
    {
    }
    public override void OnEnter()
    {
        fsm.player.cannon.Lock = true;
        fsm.player.AnimationHandler.StartShoot();
        fsm.player.AnimationHandler.OnAnimationEvent += AnimationHandler_OnAnimationEvent;
    }

    private void AnimationHandler_OnAnimationEvent(string obj)
    {
        if(obj == PlayerAnimationHandler.FIRE)
        {
            fsm.player.cannon.Shoot(fsm.player.settings.defaultBullet);
            fsm.player.AnimationHandler.OnAnimationEvent -= AnimationHandler_OnAnimationEvent;
            fsm.AdvanceTo(new PlayerIdleState(fsm));
            fsm.player.cannon.Lock = false;
        }
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
