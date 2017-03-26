using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuUI : MonoBehaviour {
    public LevelConfigs configs;
    public string GameSceneName;



    void Start () {
		
	}
	
	void Update () {
		
	}

    public void Go()
    {
        SceneManager.LoadScene(GameSceneName);
    }
}
