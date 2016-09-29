using UnityEngine;
using System.Collections;

public class EnemyLifeManager : MonoBehaviour {


    public int EnemyLife;
    public GameObject DeathEffect;
    public int PointsOnDeath;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(EnemyLife <= 0)
        {
            Instantiate(DeathEffect, transform.position, transform.rotation);
            ScoreManager.AddScore(PointsOnDeath);
            Destroy(gameObject);

        }

	}

    public void GiveDamage(int DamageToGive)
    {
        EnemyLife -= DamageToGive;
    }
}
