using UnityEngine;
using System.Collections;

public class BooEnemyMove : MonoBehaviour {


	private PlayerController thePlayer;
	public float Speed;
	public float playerRange;
	public LayerMask playerLayer;
	public bool playerInRange;
	

	void Start () {
	
		thePlayer = FindObjectOfType<PlayerController>();
		


	}
	
	// Update is called once per frame
	void Update () {

		playerInRange = Physics2D.OverlapCircle(transform.position,playerRange,playerLayer);
	
		if(playerInRange)
		transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, Speed*Time.deltaTime);
		
			

	}


	void OnDrawGizmosSelected() 
	{

		Gizmos.DrawSphere(transform.position,playerRange);


	}

}



