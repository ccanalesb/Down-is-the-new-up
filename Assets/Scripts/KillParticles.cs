using UnityEngine;
using System.Collections;

public class KillParticles : MonoBehaviour {


    private ParticleSystem thisparticlessystem;

	// Use this for initialization
	void Start () {
        thisparticlessystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (thisparticlessystem.isPlaying)
            return;

        Destroy(gameObject);   // Libera memoria por exeso de particulas creadas.
	}

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
