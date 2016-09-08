using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float Speed;
    public float Jump;
    public Transform GroundCheck;
    public float GroundCheckRadius;
    public LayerMask WhatIsGround;
    private bool Grounded;
    private bool DoubleJumped;

    private Animator anim;



	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    void FixedUpdate() {
        Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, WhatIsGround);

    }
	
	// Update is called once per frame
	void Update () {

       
        if(Grounded) { DoubleJumped = false; };  // Double Jump 

        if (Input.GetKeyDown(KeyCode.Z) && Grounded)
        { JumpFunction(); }

        
        if(Input.GetKeyDown(KeyCode.Z) && !DoubleJumped && !Grounded)   // Double Jump 
        { JumpFunction(); // Double Jump
          DoubleJumped = true; }  // Double Jump 

        if (Input.GetKey(KeyCode.RightArrow))
        { GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y); }

        if (Input.GetKey(KeyCode.LeftArrow))
        { GetComponent<Rigidbody2D>().velocity = new Vector2(-Speed, GetComponent<Rigidbody2D>().velocity.y); }

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

    }

    public void JumpFunction()
    { GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, Jump); }
}
