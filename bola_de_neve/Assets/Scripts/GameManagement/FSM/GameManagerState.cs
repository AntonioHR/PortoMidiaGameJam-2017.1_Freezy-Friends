using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSM;

public class GameManagerState : State<GameManagerFSM, GameManagerState>
{
    public GameManagerState(GameManagerFSM fsm) : base(fsm)
    {
    }
}

