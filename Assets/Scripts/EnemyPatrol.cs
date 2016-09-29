using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {


    public float Speed;
    public bool Right;

    public Transform WallCheck;
    public float WallCheckRadius;
    public LayerMask WhatIsWall;
    private bool WallHit;

    private bool NoEdge;
    public Transform EdgeCheck;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        
        WallHit = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, WhatIsWall);
        NoEdge = Physics2D.OverlapCircle(EdgeCheck.position, WallCheckRadius, WhatIsWall);

        if (WallHit || !NoEdge)            // Avanza si no esta chocando con una pared o no esta cerca de la orilla.
            Right = !Right;

        if (Right)
        {

            transform.localScale = new Vector3(-2f, 2f, 2f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);

        }
        else
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-Speed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}