using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationHandler : MonoBehaviour {
    Player player;
    Animator animator;

    public static string FIRE = "fire";

    public event Action<String> OnAnimationEvent;


    void Start () {
        animator = GetComponent<Animator>();	
	}
	
	void Update () {
		
	}

    public void OnShotKeyFrame()
    {
        player.OnShotKeyFrame();
    }

    internal void SetSpeed(float magnitude)
    {
        animator.SetFloat("Speed", magnitude);
    }
    internal void StartShoot()
    {
        animator.SetTrigger("Shoot");
    }

    public void OnEvent(string ev)
    {
        if(OnAnimationEvent != null)
        {
            OnAnimationEvent(ev);
        }
    }
}