using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSM;

public class PlayerActionFSM :FSM<PlayerActionFSM, PlayerActionState>
{

    public Player player { get; private set; }

    public PlayerActionFSM(Player player)
    {
        this.player = player;
    }
}
