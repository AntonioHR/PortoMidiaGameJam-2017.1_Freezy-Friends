using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUI : MonoBehaviour {

    public event Action OnStartAnimationDone;

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
    public void StartAnimationDone()
    {
        if(OnStartAnimationDone != null)
        {
            OnStartAnimationDone();
        }
    }
}
