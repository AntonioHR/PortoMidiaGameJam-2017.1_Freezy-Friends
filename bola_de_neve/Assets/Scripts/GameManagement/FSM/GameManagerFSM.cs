using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSM;

public class GameManagerFSM : FSM<GameManagerFSM, GameManagerState>
{

    public GameManager GameManager {get; private set;}
    public GameManagerFSM(GameManager gameManager)
    {
        this.GameManager = gameManager;
    }
}
