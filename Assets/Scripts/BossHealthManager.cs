using UnityEngine;
using System.Collections;

public class BossHealthManager : MonoBehaviour {

 public int EnemyLife;
    public GameObject DeathEffect;
    public int PointsOnDeath;
    public GameObject bossPrefab;
    public float minSize;
    public GameObject firePrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(EnemyLife <= 0)
        {
            Instantiate(DeathEffect, transform.position, transform.rotation);
            ScoreManager.AddScore(PointsOnDeath);



            //if(transform.localScale.y > minSize)
            //{
            	//GameObject clone1 = Instantiate(bossPrefab , new Vector3(transform.position.x+0.5f, transform.position.y, transform.position.z), transform.rotation) as GameObject;
            	//GameObject clone2 = Instantiate(bossPrefab , new Vector3(transform.position.x-0.5f, transform.position.y, transform.position.z), transform.rotation) as GameObject;


            	//clone1.transform.localScale = new Vector3(transform.localScale.y * 0.5f, transform.localScale.x *0.5f, transform.localScale.z);
            	//clone1.GetComponent<BossHealthManager>().EnemyLife = 10;

            	//clone2.transform.localScale = new Vector3(transform.localScale.y * 0.5f, transform.localScale.x *0.5f, transform.localScale.z);
            	//clone2.GetComponent<BossHealthManager>().EnemyLife = 10;
            //}


            GameObject clone3 = Instantiate(firePrefab , new Vector3(transform.position.x+2f, transform.position.y, transform.position.z), transform.rotation) as GameObject;
            GameObject clone4 = Instantiate(firePrefab , new Vector3(transform.position.x+5f, transform.position.y, transform.position.z), transform.rotation) as GameObject;
            GameObject clone5 = Instantiate(firePrefab , new Vector3(transform.position.x+0.5f, transform.position.y, transform.position.z), transform.rotation) as GameObject;
            Destroy(gameObject);

        }



	}

    public void GiveDamage(int DamageToGive)
    {

        EnemyLife -= DamageToGive;
        GetComponent<AudioSource>().Play();
    }
} 