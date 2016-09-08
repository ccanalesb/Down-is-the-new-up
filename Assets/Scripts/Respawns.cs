using UnityEngine;
using System.Collections;

public class Respawns : MonoBehaviour
{

    public LevelManager Manager;


    // Use this for initialization
    void Start()
    {

        Manager = FindObjectOfType<LevelManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player") { Manager.currentCheckpoint = gameObject;
            Debug.Log("Check!");
        }
    }
}
