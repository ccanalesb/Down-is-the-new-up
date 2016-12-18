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

    public AudioSource JumpSound;
    public AudioSource KiSound;

    public float Knockback;
    public float KnockbackCount;
    public float KnockbackLenght;
    public bool RightKnock;

    public float KiDelay;
    private float KiDelayCounter;
    private bool isReady;

    public TextBoxManager theTextBox;
    
    private MovPlatform currentPlatform;
    
    



	// Use this for initialization
	void Start () {

        theTextBox = FindObjectOfType<TextBoxManager>();


        anim = GetComponent<Animator>();

        isReady = true;

        KiDelayCounter = KiDelay;
	}

    void FixedUpdate() {
        Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, WhatIsGround);

    }

    // Update is called once per frame
    void Update() {



        if(Time.timeScale == 0f)
        {return;}
        

      


        if (Grounded) {
            DoubleJumped = false; };  // Double Jump
        anim.SetBool("Grounded", Grounded);

        if(Input.GetButtonDown("Submit"))
        {
            theTextBox.DisableTextBox();
        }


#if UNITY_STANDALONE || UNITY_WEBPLAYER

        if (Input.GetButtonDown("Jump") && Grounded)
        {
          JumpFunction();
          JumpSound.Play(); 
         }


        if (Input.GetButtonDown("Jump") && !DoubleJumped && !Grounded)   // Double Jump
        { JumpFunction();
          JumpSound.Play();

          DoubleJumped = true; 
         }  // Double Jump


        //Velocity = 0f;  // Con esta nueva variable hacemos que no se dezlice el personaje en el piso al utilizar el Player Material en el BoxCollider para que se deslice por las paredes y no se quede pegado.

        /*if (Input.GetKey(KeyCode.RightArrow))
        { 
            Velocity = Speed;

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        { 
            Velocity = -Speed;
        }*/
        
        //Velocity = Speed * Input.GetAxisRaw("Horizontal");
        Move(Input.GetAxisRaw("Horizontal"));
        
#endif



        if(KnockbackCount <= 0)
          { GetComponent<Rigidbody2D>().velocity = new Vector2(Velocity, GetComponent<Rigidbody2D>().velocity.y); } // Esto arregla el que no se dezlice el personaje, por eso se comenta lo de arriba.
         else {
            if(RightKnock)
            GetComponent<Rigidbody2D>().velocity = new Vector2(-Knockback, Knockback);
            if(!RightKnock)
            GetComponent<Rigidbody2D>().velocity = new Vector2(Knockback,Knockback);

            KnockbackCount -= Time.deltaTime;
         }
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        if (GetComponent<Rigidbody2D>().velocity.x > 0) { transform.localScale = new Vector3(0.8f,0.8f,0.8f) ; }   //Dar vuelta el Sprite y todas las animaciones.
        else if (GetComponent<Rigidbody2D>().velocity.x < 0) { transform.localScale = new Vector3(-0.8f,0.8f,0.8f) ; } // cont.

#if UNITY_STANDALONE || UNITY_WEBPLAYER


        if (Input.GetButtonDown("Fire1"))
        {
            //Instantiate(LightingAttack, FirePoint.position, FirePoint.rotation);
            FireGun();
        }
        
        if(!isReady)
        {
           KiDelayCounter -= Time.deltaTime; 
        }

        if(KiDelayCounter <= 0)
        {
            isReady = true;
            KiDelayCounter = KiDelay;
        }


        if(anim.GetBool("Ki"))
            {
                //anim.SetBool("Ki",false);
                ResetKi();
            }

        /*if(Input.GetKeyDown(KeyCode.C))
        {
            anim.SetBool("Ki",true);
          KiSound.Play();
         KiDelayCounter = KiDelay;
        } */

        if(Input.GetButtonDown("Fire2"))
        {
            
            //KiDelayCounter -= Time.deltaTime;

            //if(KiDelayCounter <= 0)
             if(isReady)
             {
               isReady = false;
               //KiDelayCounter = KiDelay;
               //anim.SetBool("Ki",true);
               KiAttack();
               
               
             }
        }


#endif 




    }

    public void FireGun()
    {
        Instantiate(LightingAttack, FirePoint.position, FirePoint.rotation);
    }

    public void KiAttack()
    {
        anim.SetBool("Ki",true);
        KiSound.Play();  
       
    }

    public void ResetKi()
    {
        anim.SetBool("Ki",false);
    }

    public void Move(float moveInput)
    {
    	 Velocity = Speed * moveInput;
    }


    public void JumpFunction()
    { 
        //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, Jump);

        if (Grounded)
        {
          //JumpFunction();
          GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, Jump);
          JumpSound.Play(); 
         }


        if (!DoubleJumped && !Grounded)   // Double Jump
        { //JumpFunction();
          GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, Jump);  
          JumpSound.Play();

          DoubleJumped = true; 
         }  // Double Jump
     }



    void OnCollisionEnter2D(Collision2D other)
    {

        if(other.transform.tag == "Mov Platform")
        {
            var correct = new GameObject("Correct");
            correct.transform.parent = other.transform;
            correct.transform.localScale = new Vector3(1/other.transform.localScale.x, 1/other.transform.localScale.y, 1/other.transform.localScale.z);
            transform.parent = correct.transform;
            
        }   
    }


    void OnCollisionExit2D(Collision2D other)
    {
        if(other.transform.tag == "Mov Platform")
        {transform.parent = null;
        Destroy(other.transform.Find("Correct").gameObject);}
    }
}
