using UnityEngine;
using System.Collections;

public class Pickups : MonoBehaviour {

    public int PointsToAdd; 
    public AudioSource coinSound;

    void OnTriggerEnter2D (Collider2D other)
    {

        if (other.GetComponent<PlayerController>() == null)  // Evitar que otra persona aparte del PLAYER tome las hueas.
            return;

        ScoreManager.AddScore(PointsToAdd);
        coinSound.Play();


        Destroy(gameObject);
    }
}
