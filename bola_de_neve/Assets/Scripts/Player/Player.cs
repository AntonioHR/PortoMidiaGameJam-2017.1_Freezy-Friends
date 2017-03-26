using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Serializable]
    public class Settings
    {
        public BulletData defaultBullet;
        public string name;
        public float dashForce = 40;
        public float dashTime;
        public int startLife = 3;
    }

    public GameObject[] lifeIndicators;

    public GameObject Corpse;

    int life;
    public Settings settings;
    public Cannon cannon;
    public int Points { get; private set; }

    public Rigidbody Body { get; private set; }
    public PlayerInput PlayerInput { get; private set; }
    public PlayerUI PlayUI { get; private set; }

    internal void DashDown()
    {
        fsm.Current.OnDashDown();
    }

    public PlayerAnimationHandler AnimationHandler;

    public event Action<Player> OnDie;




    public PlayerActionFSM fsm;

    public bool awaitLevelStart = false;

    public bool CanMove
    {
        get
        {
            return fsm.Current.CanMove;
        }
    }

    public bool Dead
    {
        get
        {
            return fsm.Current.Dead;
        }
    }
    public bool CanBreak
    {
        get
        {
            return fsm.Current.CanBreak;
        }
    }


    void Start () {
        life = settings.startLife;
        cannon.owner = this;
        Body = GetComponent<Rigidbody>();
        PlayerInput = GetComponent<PlayerInput>();
        PlayUI = GetComponent<PlayerUI>();
        fsm = new PlayerActionFSM(this);
        if (awaitLevelStart)
            fsm.Push(new PlayerStartState(fsm));
        else
            fsm.Push(new PlayerIdleState(fsm));
	}

    internal void HitBy(Bullet bullet)
    {
        if (life == 0)
            return;
        //var direction = (transform.position - bullet.transform.position).normalized;
        //var direction = bullet.GetComponent<Rigidbody>().velocity.normalized;
        var direction = bullet.ImpactVec.normalized;
        Body.AddForce(direction * bullet.settings.Impact, ForceMode.Impulse);
        life--;
        if (life <= 0)
        {
            life = 0;
            fsm.AdvanceTo(new PlayerDeadState(fsm));
            Points = Math.Max(0, Points - 1);
            bullet.Owner.KilledOne();
        }
    }

    private void KilledOne()
    {
        Points++;
    }

    public void YouWin()
    {
        fsm.AdvanceTo(new PlayerWinState(fsm));
    }

    
    public void YouLose()
    {
        fsm.AdvanceTo(new PlayerLoseState(fsm));
    }

    void Update () {
        fsm.Current.Update();
        AnimationHandler.SetSpeed(Body.velocity.magnitude);
        for (int i = 0; i < lifeIndicators.Length; i++)
        {
            var lostLife = settings.startLife - life;
            lifeIndicators[i].SetActive((lostLife) > i);
        }
    }

    public void ShootUp()
    {
        fsm.Current.ShootUp();
    }

    public void ShootDown()
    {
        fsm.Current.ShootDown();
    }
    public void OnBattleStart()
    {
        fsm.AdvanceTo(new PlayerIdleState(fsm));
    }

    public static Player GetFromCollider(Collider col)
    {
        var player = col.GetComponent<Player>();
        var body = col.GetComponent<PlayerBody>();
        if (body != null && player == null)
        {
            player = body.owner;
        }
        return player;
    }
    

    public void Die()
    {
        gameObject.SetActive(false);
        GameObject.Instantiate(Corpse, transform.position, transform.rotation);
        if (OnDie != null)
            OnDie(this);
    }
    internal void Respawn()
    {
        life = settings.startLife;
        gameObject.SetActive(true);
    }
}
