using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    private PlayerController Player;
    public GameObject deathparticle;
    public GameObject respawnparticle;
    public float respawntime;
    public int DeathPointPenalty;
    private float GravitySave;
    private CameraController Camera;
    public LifeManager lifeManager;
    
    
    // Use this for initialization
	void Start () {
        Player = FindObjectOfType<PlayerController>();
        Camera = FindObjectOfType<CameraController>();

        lifeManager = FindObjectOfType<LifeManager>();
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
        Camera.isFollowing = false;


        GravitySave = Player.GetComponent<Rigidbody2D>().gravityScale;   // No son necesarios despues de programar el CameraController script.
        Player.GetComponent<Rigidbody2D>().gravityScale = 0f;          // Pero, esto me ayuda a evitar que si se lagea, no se alcance a activar el Renderer (Box collider) del personaje y mucera al instante.
        //Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;  // Esto sirve para que al morir el personaje se quede quieto, puede ser util, pero al tener control de la camara, hacemos que esta se quede quieta.
        ScoreManager.AddScore(-DeathPointPenalty);
        Debug.Log("Player Respawn");
        yield return new WaitForSeconds(respawntime);
        Player.GetComponent<Rigidbody2D>().gravityScale = GravitySave;
        Player.transform.position = currentCheckpoint.transform.position;
        Player.KnockbackCount = 0;
        Player.GetComponent<Renderer>().enabled = true;
        Player.enabled = true;

        lifeManager.FullLife();
        lifeManager.isDead = false;
        
        Camera.isFollowing = true;
        Instantiate(respawnparticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }
}
