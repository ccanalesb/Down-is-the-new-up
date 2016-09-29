using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float Speed;
    public float Jump;
    private float Velocity;
    public Transform GroundCheck;
    public float GroundCheckRadius;
    public LayerMask WhatIsGround;
    private bool Grounded;
    private bool DoubleJumped;

    private Animator anim;

    public Transform FirePoint;
    public GameObject LightingAttack;



	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    void FixedUpdate() {
        Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, WhatIsGround);

    }

    // Update is called once per frame
    void Update() {


        if (Grounded) {
            DoubleJumped = false; };  // Double Jump
        anim.SetBool("Grounded", Grounded);

        if (Input.GetKeyDown(KeyCode.Z) && Grounded)
        { JumpFunction(); }


        if (Input.GetKeyDown(KeyCode.Z) && !DoubleJumped && !Grounded)   // Double Jump
        { JumpFunction(); // Double Jump
            DoubleJumped = true; }  // Double Jump


        Velocity = 0f;  // Con esta nueva variable hacemos que no se dezlice el personaje en el piso al utilizar el Player Material en el BoxCollider para que se deslice por las paredes y no se quede pegado.

        if (Input.GetKey(KeyCode.RightArrow))
        { //GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);
            Velocity = Speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        { //GetComponent<Rigidbody2D>().velocity = new Vector2(-Speed, GetComponent<Rigidbody2D>().velocity.y);
            Velocity = -Speed;
        }


        GetComponent<Rigidbody2D>().velocity = new Vector2(Velocity, GetComponent<Rigidbody2D>().velocity.y); // Esto arregla el que no se dezlice el personaje, por eso se comenta lo de arriba.

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        if (GetComponent<Rigidbody2D>().velocity.x > 0) { transform.localScale = new Vector3(0.8f,0.8f,0.8f) ; }   //Dar vuelta el Sprite y todas las animaciones.
        else if (GetComponent<Rigidbody2D>().velocity.x < 0) { transform.localScale = new Vector3(-0.8f,0.8f,0.8f) ; } // cont.

        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(LightingAttack, FirePoint.position, FirePoint.rotation);
        }
    }

    public void JumpFunction()
    { GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, Jump); }
}
