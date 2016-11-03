using UnityEngine;
using System.Collections;

public class LivePickup : MonoBehaviour {

	
	private LivesManager liveSystem;
	public AudioSource LiveSound;
	// Use this for initialization
	void Start () {
	
	 liveSystem = FindObjectOfType<LivesManager>();
	}
	
	// Update is called once per frame
	
	void OnTriggerEnter2D(Collider2D other)
	{
		
		
			if (other.GetComponent<PlayerController>() == null)  // Evitar que otra persona aparte del PLAYER tome las hueas.
            return;

			liveSystem.GiveLive();
			LiveSound.Play();
			Destroy(gameObject);
		
	}
}
