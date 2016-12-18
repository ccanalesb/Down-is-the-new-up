using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class LifeManager : MonoBehaviour {

    public static int PlayerLife;
    //public int MaxPlayerLife;
    //Text LifeQuality;
    public Slider healthBar;
    private LevelManager LevelManag;
    public bool isDead;
    private LivesManager liveSystem;
    private static int maxPlayerLife;
    
    
    // Use this for initialization
	void Start () {
        //LifeQuality = GetComponent<Text>();
        healthBar = GetComponent<Slider>();
        PlayerLife = PlayerPrefs.GetInt("PlayerCurrentHealth");
        maxPlayerLife = PlayerPrefs.GetInt("PlayerMaxHealth");
        LevelManag = FindObjectOfType<LevelManager>();
        isDead = false;

        liveSystem = FindObjectOfType<LivesManager>();
	}
	
	// Update is called once per frame
	void Update () {

	   if(PlayerLife <= 0 && !isDead)
        {
            PlayerLife = 0;
            LevelManag.RespawnPlayer();
            liveSystem.TakeLive();
            isDead = true;
        }

        if(PlayerLife > maxPlayerLife)
        PlayerLife = maxPlayerLife;

        healthBar.value = PlayerLife;

        //LifeQuality.text = "" + PlayerLife;
	}

    public static void DamagePlayer(int HitDamage)
    {
        PlayerLife -= HitDamage;
        PlayerPrefs.SetInt("PlayerCurrentHealth",PlayerLife);
    }

    public void FullLife()
    {
        PlayerLife = PlayerPrefs.GetInt("PlayerMaxHealth");
        PlayerPrefs.SetInt("PlayerCurrentHealth",PlayerLife);
        

    }
}
