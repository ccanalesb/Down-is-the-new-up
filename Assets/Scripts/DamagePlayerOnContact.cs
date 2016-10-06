using UnityEngine;
using System.Collections;

public class DamagePlayerOnContact : MonoBehaviour {

    public int Damage;
    


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player") 
        {

         LifeManager.DamagePlayer(Damage); 
         other.GetComponent<AudioSource>().Play();

         var player = other.GetComponent<PlayerController>();
         player.KnockbackCount = player.KnockbackLenght;

         if(other.transform.position.x < transform.position.x)
         player.RightKnock = true;

         else 
         player.RightKnock = false;

         }

    }
}
