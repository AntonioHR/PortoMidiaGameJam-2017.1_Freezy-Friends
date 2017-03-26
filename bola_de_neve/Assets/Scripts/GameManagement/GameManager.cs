using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public List<Player> players { get; private set; }
    public BattleUI BattleUI;

    public Transform respawnPointsParent;
    public Transform spawnPointsParent;
    public CameraControl CameraRig;

    public GameObject[] playerPrefabs;
    public int defaultPlayerCount = 4;

    [System.Serializable]
    public class Settings
    {
        public int pointsToWin = 5;
        public float respawnTime = 4;
    }
    public Settings settings;
    

    GameManagerFSM fsm;
    
	void Start () {
        var levelConfigs = FindObjectOfType<LevelConfigs>();
        int playerCount = levelConfigs == null? defaultPlayerCount : levelConfigs.playerCount;
        settings.pointsToWin = levelConfigs == null? settings.pointsToWin : levelConfigs.PointsToWin;
        Debug.Assert(playerPrefabs.Length >= playerCount);
        fsm = new GameManagerFSM(this);
        fsm.AdvanceTo(new GameManagerStartState(fsm));

        players = new List<Player>();
        CameraRig.m_Targets = new Transform[playerCount];
        for (int i = 0; i < playerPrefabs.Length && i < playerCount; i++)
        {
            players.Add(GameObject.Instantiate(playerPrefabs[i]).GetComponent<Player>());
            players[i].OnDie += Player_OnDie;
            CameraRig.m_Targets[i] = players[i].transform;
        }
	}

    private void Player_OnDie(Player obj)
    {
        RespawnPlayerIn(obj);
    }

    void Update () {
        fsm.Current.Update();

    }

    public void CheckForWinner()
    {
        var winner = players.Find((x) => x.Points >= settings.pointsToWin);
        if (winner != null)
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
