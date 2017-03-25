using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameManagerStartState : GameManagerState
{
    public GameManagerStartState(GameManagerFSM fsm) : base(fsm)
    {
    }

    public override void OnEnter()
    {
        fsm.GameManager.BattleUI.StartStartAnimation();
        fsm.GameManager.BattleUI.OnStartAnimationDone += BattleUI_OnStartAnimationDone;
    }

    private void BattleUI_OnStartAnimationDone()
    {
        fsm.AdvanceTo(new GameManagerInGameState(fsm));
        fsm.GameManager.BattleUI.OnStartAnimationDone -= BattleUI_OnStartAnimationDone;
    }
}
