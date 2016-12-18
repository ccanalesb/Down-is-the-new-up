using UnityEngine;
using System.Collections;

public class HealPlayerOnContact : MonoBehaviour {

    public int Heal; 
    public AudioSource healSound;

    void OnTriggerEnter2D (Collider2D other)
    {

        if (other.GetComponent<PlayerController>() == null)  // Evitar que otra persona aparte del PLAYER tome las hueas.
            return;

        LifeManager.DamagePlayer(Heal);
        healSound.Play();


        Destroy(gameObject);
    }
}
