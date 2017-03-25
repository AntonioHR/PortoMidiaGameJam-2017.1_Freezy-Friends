using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameManagerInGameState : GameManagerState
{
    public GameManagerInGameState(GameManagerFSM fsm) : base(fsm)
    {
    }
    public override void OnEnter()
    {
        fsm.GameManager.StartGame();
    }
}