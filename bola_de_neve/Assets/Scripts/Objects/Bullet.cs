using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public HomeToPlayers homing;
    public PlayerDetector detector;
    public Rigidbody body;

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
        if (player != null)
        {
            player.HitBy(this);
        }
    }

    public void SetOwner(Player owner)
    {
        detector.Ignore(owner);
    }

}
