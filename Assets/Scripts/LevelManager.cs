<<<<<<< HEAD
﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    private PlayerController Player;
    
    // Use this for initialization
	void Start () {
        Player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void RespawnPlayer() {
        Debug.Log("Player Respawn");
        Player.transform.position = currentCheckpoint.transform.position;
    }
}
=======
﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    private PlayerController Player;
    public GameObject deathparticle;
    public GameObject respawnparticle;
    public float respawntime;
    public int DeathPointPenalty;
    private float GravitySave;
    
    
    // Use this for initialization
	void Start () {
        Player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(deathparticle, Player.transform.position, Player.transform.rotation);
        Player.enabled = false;
        Player.GetComponent<Renderer>().enabled = false;
        GravitySave = Player.GetComponent<Rigidbody2D>().gravityScale;
        Player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ScoreManager.AddScore(-DeathPointPenalty);
        Debug.Log("Player Respawn");
        yield return new WaitForSeconds(respawntime);
        Player.GetComponent<Rigidbody2D>().gravityScale = GravitySave;
        Player.transform.position = currentCheckpoint.transform.position;
        Player.enabled = true;
        Player.GetComponent<Renderer>().enabled = true;
        Instantiate(respawnparticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }
}
>>>>>>> af20394a6d0f736a2b7a3b6b56c3e278d28fc4d6
