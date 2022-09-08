using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
public GameObject bullet;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    public int salto = 0;
    public float velocity = 10;
    public float vcaminar =4;
    private Vector2 direction;
    const int ANIMATION_QUIETO =0;
    const int ANIMATION_CAMINAR =1;
    const int ANIMATION_SALTAR =2;
    const int ANIMATION_CORRER =3;
    const int ANIMATION_ATACAR =4;
    const int ANIMATION_MORIR =5;
    public float jumpForce =5;
    public int balas =0;
    bool puedeSaltar =true;
    //private Vector3 lastCheckpointPosition;
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
        //rb.velocity = new Vector2(0,rb.velocity.y);
        //changeAnimation(ANIMATION_QUIETO);
        //CAMINAR
        //if (Input.GetKey(KeyCode.RightArrow)){
            rb.velocity = new Vector2(velocity, rb.velocity.y);
            //sr.flipX=false;
            changeAnimation(ANIMATION_CAMINAR);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow)){
             //rb.velocity = new Vector2(-vcaminar, rb.velocity.y);
             //sr.flipX=true;
             //changeAnimation(ANIMATION_CAMINAR);
             
        //}
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
        if (Input.GetKeyUp(KeyCode.Space))
        {
          if(salto<2){
             rb.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
            changeAnimation(ANIMATION_SALTAR);
            salto +=1;
          }         
        }
        if(Input.GetKey(KeyCode.Z)){
            changeAnimation(ANIMATION_ATACAR);
        }
        if (Input.GetKeyUp(KeyCode.X)&&balas<5){
        var BulletPosition = transform.position + new Vector3(3,0,0);//Lugar donde aparecera la bala
        var gb = Instantiate(bullet, BulletPosition,Quaternion.identity) as GameObject;
        var controller =gb.GetComponent<BulletController>();
        controller.SetRightDirection();
        
        }
    }
    
    void OnCollisionEnter2D(Collision2D other){
        salto = 0;
      if(other.gameObject.tag == "Enemigo"){
        changeAnimation(ANIMATION_MORIR);
      }
      //if(other.gameObject.name =="DarkHole"){//Regresar al checkpoint
       // if(lastCheckpointPosition != null){
          //transform.position = lastCheckpointPosition;
       // }
     // }
    }
    /*void OnTriggerEnter2D(Collider2D other){//Puede traspasar el objeto
      Debug.Log("trigger");
      lastCheckpointPosition = transform.position;
    }*/
    void changeAnimation (int animation){
        animator.SetInteger("Estado",animation);
    }
}
