using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    public float velocity = 10;
    public float vcaminar =4;
    const int ANIMATION_QUIETO =0;
    const int ANIMATION_CAMINAR =1;
    const int ANIMATION_SALTAR =2;
    const int ANIMATION_CORRER =3;
    const int ANIMATION_ATACAR =4;
    public float jumpForce =5;
    bool puedeSaltar =true;
    void Start()
    {
       Debug.Log("Inicializando"); 
       rb = GetComponent<Rigidbody2D>();
       sr = GetComponent<SpriteRenderer>();
       animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0,rb.velocity.y);
        changeAnimation(ANIMATION_QUIETO);
        if (Input.GetKey(KeyCode.RightArrow)){
            rb.velocity = new Vector2(vcaminar, rb.velocity.y);
            sr.flipX=false;
            changeAnimation(ANIMATION_CAMINAR);
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
             rb.velocity = new Vector2(-vcaminar, rb.velocity.y);
             sr.flipX=true;
             changeAnimation(ANIMATION_CAMINAR);
             
        }
        if (Input.GetKey(KeyCode.RightArrow)&& Input.GetKey(KeyCode.X)){
            rb.velocity = new Vector2(velocity, rb.velocity.y);
            sr.flipX=false;
            changeAnimation(ANIMATION_CORRER);
        }
        if (Input.GetKey(KeyCode.LeftArrow)&& Input.GetKey(KeyCode.X)){
             rb.velocity = new Vector2(-velocity, rb.velocity.y);
             sr.flipX=true;
             changeAnimation(ANIMATION_CORRER);
             
        }
        if (Input.GetKeyUp(KeyCode.Space)&& puedeSaltar)
        {
            rb.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
            puedeSaltar = false;
            changeAnimation(ANIMATION_SALTAR);
        }
    }
    void changeAnimation (int animation){
        animator.SetInteger("Estado",animation);
    }
}
