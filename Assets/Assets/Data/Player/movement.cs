using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{ 
    //
    [SerializeField] private float dirX = 0f;

    [SerializeField] private float speed = 3;
    [SerializeField] private float jumpForce = 8;
    public bool allowJump;
    public bool isFacingRight = true;

    [SerializeField] protected LayerMask mask;

    protected Rigidbody2D rb;
    public Animator anim;


    private void Awake()
    {
        AudioManager.instance.SFXRun.clip = AudioManager.instance.run;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {//
        dirX = Input.GetAxisRaw("Horizontal");    
        //
        if(isFacingRight && dirX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isFacingRight = false;
        }
        if(!isFacingRight && dirX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isFacingRight = true;
        }
        
        Movement();
        updateAnim();

        
    }

    //di chuyen
    void Movement()
    {
        transform.Translate(dirX * speed * Time.deltaTime,0,0);

        if (isGrouded() == false && allowJump == false)
        {
            AudioManager.instance.SFXRun.Stop();
        }
        else
        {
            if (dirX == 0)
            {
                AudioManager.instance.SFXRun.Play();
            }
        }

        if (isGrouded())
        {
            allowJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            rb.drag = 0;
            if (allowJump)
            {//
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                AudioManager.instance.PlaySFX(AudioManager.instance.jump);
                allowJump = false;
            }
            if (isGrouded())
            {
                AudioManager.instance.PlaySFX(AudioManager.instance.jump);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            
        }
        
        
    }

    protected enum MoveState { idle, running, jumping, falling }
    MoveState moveState;
    //cap nhat animation nhan vat
    void updateAnim()
    {
        
        if (dirX > 0)
        {          
            moveState = MoveState.running;

        }
        else if (dirX < 0)
        {
            moveState = MoveState.running;

        }
        else
        {   

            moveState = MoveState.idle;
        }



        if (rb.velocity.y > .1f)
        {
            moveState = MoveState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            moveState = MoveState.falling;
        }

        anim.SetInteger("state", (int)moveState);
    }

    //check cham mat dat
    public bool isGrouded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 1.1f, mask);
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player" || collision.tag == "rollingdoor")
        {
            allowJump = true;

        }
//
    }
    //
}
