using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameManagerBattleOverState : GameManagerState
{
    Player winner;
    public GameManagerBattleOverState(GameManagerFSM fsm, Player winner) : base(fsm)
    {
        this.winner = winner;
    }
    public override void OnEnter()
    {
        fsm.GameManager.BattleUI.StartBattleOverAnimation(winner.settings.name);
    }
}
