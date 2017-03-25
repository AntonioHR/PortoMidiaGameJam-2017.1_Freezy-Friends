using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSM;
using UnityEngine;

public abstract class PlayerActionState : State<PlayerActionFSM, PlayerActionState>
{

    public PlayerActionState(PlayerActionFSM fsm) : base(fsm)
    {
    }

    public abstract bool CanMove { get; }

    public abstract void ShootUp();

    public abstract void ShootDown();


}
