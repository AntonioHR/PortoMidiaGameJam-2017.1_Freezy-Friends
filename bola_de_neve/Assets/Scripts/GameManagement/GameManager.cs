using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Player[] players;
    public BattleUI BattleUI;

    GameManagerFSM fsm;
    
	void Start () {
        fsm = new GameManagerFSM(this);
        fsm.AdvanceTo(new GameManagerStartState(fsm));
	}
	
	void Update () {
        fsm.Current.Update();
	}
    
    public void StartGame()
    {
        foreach (var player in players)
        {
            player.OnBattleStart();
        }
    }
}
