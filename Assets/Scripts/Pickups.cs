using UnityEngine;
using System.Collections;

public class Pickups : MonoBehaviour {

    public int PointsToAdd; 

    void OnTriggerEnter2D (Collider2D Other)
    {

        if (Other.GetComponent<PlayerController>() == null)  // Evitar que otra persona aparte del PLAYER tome las hueas.
            return;

        ScoreManager.AddScore(PointsToAdd);

        Destroy(gameObject);
    }
}
