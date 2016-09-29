using UnityEngine;
using System.Collections;

public class DestroyObjectOverTime : MonoBehaviour {


    public float Lifetime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Lifetime -= Time.deltaTime;

        if(Lifetime < 0)
        {

            Destroy(gameObject);
            
        }
	}
}
