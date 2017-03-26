using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public List<Player> players;
    public BattleUI BattleUI;

    public Transform respawnPointsParent;

    [System.Serializable]
    public class Settings
    {
        public int pointsToWin = 5;
        public float respawnTime = 4;
    }
    public Settings settings;
    

    GameManagerFSM fsm;
    
	void Start () {
        fsm = new GameManagerFSM(this);
        fsm.AdvanceTo(new GameManagerStartState(fsm));
        foreach (var player in players)
        {
            player.OnDie += Player_OnDie;
        }
	}

    private void Player_OnDie(Player obj)
    {
        RespawnPlayerIn(obj);
    }

    void Update () {
        fsm.Current.Update();

        var winner = players.Find((x) => x.Points >= settings.pointsToWin);
        if(winner != null)
        {
            winner.YouWin();
            players.FindAll((x) => x != winner).ForEach((x) => x.YouLose());
            fsm.AdvanceTo(new GameManagerBattleOverState(fsm, winner));
        }
    }
    
    public void StartGame()
    {
        foreach (var player in players)
        {
            player.OnBattleStart();
        }
    }

    public void RespawnPlayerIn(Player p)
    {
        StartCoroutine(RespawnPlayerCoroutine(p, settings.respawnTime));
    }

    IEnumerator RespawnPlayerCoroutine(Player p, float time)
    {
        yield return new WaitForSeconds(time);
        //var points = respawnPointsParent.child
        var random = Random.Range(0, respawnPointsParent.childCount);

        var offset = new Vector3(Random.value, 0, Random.value);
        p.transform.position = respawnPointsParent.GetChild(random).position + offset*5;
        p.Respawn();
    }

    private void OnDrawGizmosSelected()
    {
        foreach (Transform child in respawnPointsParent)
        {
            Gizmos.DrawSphere(child.position, 1f);
        }
    }
}
