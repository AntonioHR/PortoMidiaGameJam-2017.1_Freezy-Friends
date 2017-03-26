using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBattleOverState : GameManagerState
{
    Player winner;
    float endTime;
    bool end;
    public GameManagerBattleOverState(GameManagerFSM fsm, Player winner) : base(fsm)
    {
        this.winner = winner;
        endTime = Time.time + 5;
    }
    public override void OnEnter()
    {
        fsm.GameManager.BattleUI.StartBattleOverAnimation(winner.settings.name);


    }

    public override void Update()
    {
        if(!end && endTime < Time.time)
        {
            end = true;
            //
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
