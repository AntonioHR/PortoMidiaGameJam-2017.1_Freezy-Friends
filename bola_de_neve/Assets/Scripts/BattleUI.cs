using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour {

    public event Action OnStartAnimationDone;

    public Text battleOverText;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
	void Start () {
		
	}
	
	void Update () {
		
	}
    public void StartStartAnimation()
    {
        animator.SetTrigger("Start");
    }

    public void StartBattleOverAnimation(string playerName)
    {
        battleOverText.text = string.Format("{0} Won", playerName);
        animator.SetTrigger("Over");
    }
    public void StartAnimationDone()
    {
        if(OnStartAnimationDone != null)
        {
            OnStartAnimationDone();
        }
    }
}
