﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerStartState : PlayerActionState
{
    public PlayerStartState(PlayerActionFSM fsm) : base(fsm)
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