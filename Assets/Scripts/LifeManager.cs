using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class LifeManager : MonoBehaviour {

	public static int PlayerLife;
	public int MaxPlayerLife;
	Text LifeQuality;
	private LevelManager LevelManag;
	public bool isDead;


	// Use this for initialization
	void Start () {
		LifeQuality = GetComponent<Text>();
		PlayerLife = MaxPlayerLife;
		LevelManag = FindObjectOfType<LevelManager>();
		isDead = false;
	}

	// Update is called once per frame
	void Update () {

		if(PlayerLife <= 0 && !isDead)
		{
			PlayerLife = 0;
			LevelManag.RespawnPlayer();
			isDead = true;
		}
		LifeQuality.text = "" + PlayerLife;
	}

	public static void DamagePlayer(int HitDamage)
	{
		PlayerLife -= HitDamage;
	}

	public void FullLife()
	{
		PlayerLife = MaxPlayerLife;
	}
}