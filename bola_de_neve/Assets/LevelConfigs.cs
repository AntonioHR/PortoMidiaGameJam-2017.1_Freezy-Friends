using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConfigs : MonoBehaviour {
    public int playerCount = 4;
    public int PointsToWin = 3;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
