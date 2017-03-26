using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerImpactState : PlayerActionState
{
    float endTime;
    public PlayerImpactState(PlayerActionFSM fsm, float time) : base(fsm)
    {
        endTime = Time.time + time;
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
    }
    public override void Update()
    {
        if(Time.time > endTime)
        {
            fsm.AdvanceTo(new PlayerIdleState(fsm));
        }
    }
    public override void ShootDown()
    {
    }

    public override void ShootUp()
    {
    }
}
