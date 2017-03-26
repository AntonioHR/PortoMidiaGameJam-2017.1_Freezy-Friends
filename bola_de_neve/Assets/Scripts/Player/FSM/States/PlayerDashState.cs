using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerDashState : PlayerActionState
{
    float endTime;
    public PlayerDashState(PlayerActionFSM fsm) : base(fsm)
    {
        endTime = Time.time + fsm.player.settings.dashTime;
    }

    public override bool CanMove
    {
        get
        {
            return false;
        }
    }

    public override bool CanBreak
    {
        get
        {
            return false;
        }
    }

    public override void OnEnter()
    {
        var player = fsm.player;
        //player.Body.AddForce(player.transform.TransformDirection(Vector3.forward) * player.settings.dashForce, ForceMode.VelocityChange);

        fsm.player.Body.velocity = player.transform.TransformDirection(Vector3.forward) * player.settings.dashForce;
        player.AnimationHandler.StartDashAnimation();
    }

    public override void OnLeave()
    {
        fsm.player.AnimationHandler.StopDashAnimation();
        fsm.player.Body.velocity = Vector3.zero;
    }
    public override void Update()
    {
        if (Time.time > endTime)
            fsm.AdvanceTo(new PlayerIdleState(fsm));
    }

    public override void ShootDown()
    {
    }

    public override void ShootUp()
    {
    }
}