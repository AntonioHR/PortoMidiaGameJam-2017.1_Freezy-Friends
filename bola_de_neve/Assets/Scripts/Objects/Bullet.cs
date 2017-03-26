using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public HomeToPlayers homing;
    public PlayerDetector detector;
    public Rigidbody body;

    Player owner;

    public Player Owner { get { return owner; } }

    public Vector3 ImpactVec { get; private set; }

    public Settings settings;
    [System.Serializable]
    public class Settings
    {
        public float Impact = 10;
    }


	void Awake () {
        Debug.Assert(homing != null);
        Debug.Assert(detector != null);
        Debug.Assert(body != null);
	}

    void Start()
    {
        ImpactVec = body.velocity;
    }
    void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Destroy(homing);
            Destroy(gameObject, 1);
            Destroy(this);
        }
        var player = Player.GetFromCollider(collision.collider);
        if (player != null && player != owner)
        {
            player.HitBy(this);
        }
    }

    public void SetOwner(Player owner)
    {
        this.owner = owner;
        detector.Ignore(owner);
    }

}
