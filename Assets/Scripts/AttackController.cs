using UnityEngine;
using System.Collections;

public class AttackController : MonoBehaviour {


    public float AttackSpeed;
    public PlayerController player;

    
    public GameObject ImpactEffect;

    

    public int damage;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        

        if (player.transform.localScale.x < 0)
            AttackSpeed = -AttackSpeed;
    }

	// Update is called once per frame
	void Update () {

        GetComponent<Rigidbody2D>().velocity = new Vector2(AttackSpeed, GetComponent<Rigidbody2D>().velocity.y);

    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Enemy")    // Aca esta lo que pasa cuando el collider del ataque choca con el del "Enemy".
        {
            other.GetComponent<EnemyLifeManager>().GiveDamage(damage);



        }

        if(other.tag == "Boss")
        {
            other.GetComponent<BossHealthManager>().GiveDamage(damage);
        }
        Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
