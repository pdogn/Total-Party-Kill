using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Die_Anim : MonoBehaviour
{
    Collider2D col;
    [SerializeField] private LayerMask mask;

    Animator anim;
    public ParticleSystem eff;
    [SerializeField] public bool die_trap, die_frozen, die_arrow, die_sword;///
    
    public bool Die_sw { get => die_sword;set { die_sword = value; } }
    BoxCollider2D boxCollider;
    public bool Die_arrow { get => die_arrow; }

    public bool vck = false;

   
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        
        boxCollider = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(col.bounds.center, Vector2.right, Color.red);
        Debug.DrawRay(col.bounds.center, Vector2.left, Color.red);
        Debug.DrawRay(col.bounds.center, Vector2.down, Color.red);

        
    }

    private void FixedUpdate()
    {
        updateDieState();
    }

    public enum DieState { n, dieTrap, dieFrozen, dieArrow, dieSword }

    DieState dieState;

    void updateDieState()
    {
        if (die_trap)
        {
            dieState = DieState.dieTrap;
            this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<BoxCollider2D>().size = new Vector2(1.2f, 0.5f);
            GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.7f);
            this.gameObject.GetComponent<PlayerLife>().currentState = PlayerLife.CharacterState.Dead;
        }
        if (die_arrow)
        {
            DieArrowLogic();
            GetComponent<BoxCollider2D>().size = new Vector2(1.3f, 1.36f);
            GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.3f);

        }
        if (die_frozen)
        {
            
            DieFrozenLogic();
            GetComponent<BoxCollider2D>().size = new Vector2(1.3f, 1.36f);
            GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.3f);


        }
        if (die_sword)
        {
            DieSwordLogic();
            GetComponent<BoxCollider2D>().size = new Vector2(1.2f, 0.5f);
            GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.7f);
            //dieState = DieState.dieSword;
            //this.gameObject.GetComponent<PlayerLife>().currentState = PlayerLife.CharacterState.Dead;
        }

        anim.SetInteger("ds", (int)dieState);

    }

    void DieArrowLogic()
    {       
        die_trap = false;
        die_sword = false;
        
        dieState = DieState.dieArrow;
        this.gameObject.GetComponent<PlayerLife>().currentState = PlayerLife.CharacterState.Dead;

        if (isRGrounded() || isLGrounded())
        {
            //rb.bodyType = RigidbodyType2D.Static;
            this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        else if (vck)
        {
            this.gameObject.GetComponent<Rigidbody2D>().drag = 150;
            die_arrow = false;
            die_trap = true;
            dieState = DieState.dieTrap;
            //vck = false;
        }
    }
    void DieFrozenLogic()
    {
        die_arrow = false;
        die_trap = false;
        die_sword = false;
        dieState = DieState.dieFrozen;
        
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        this.gameObject.GetComponent<PlayerLife>().currentState = PlayerLife.CharacterState.Dead;
        if (isGrounded())
        {
            this.gameObject.GetComponent<Rigidbody2D>().drag = 20;
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody2D>().drag = 0;
        }
        //this.gameObject.GetComponent<Rigidbody2D>().drag = 90;
    }

    void DieSwordLogic()
    {
        
        dieState = DieState.dieSword;
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        this.gameObject.GetComponent<PlayerLife>().currentState = PlayerLife.CharacterState.Dead;
        

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "arrow")
        {
            die_arrow = true;
        }
        if (collision.tag == "ice_bullet")
        {
            die_frozen = true;
            eff.Play();
        }
        if (collision.tag == "trap")
        {
            die_trap = true;
        }
        //if (collision.tag == "sword")
        //{
        //    die_sword = true;
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player" || collision.gameObject.tag == "rollingdoor")
        {
            vck = true;
        }
        
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player" || collision.gameObject.tag == "rollingdoor")
        {
            vck = false;
        }
        
    }

    private bool isRGrounded()
    {
        return Physics2D.Raycast(col.bounds.center, Vector2.right, .8f, mask);
    }
    //va cham trai
    private bool isLGrounded()
    {
        return Physics2D.Raycast(col.bounds.center, Vector2.left, .8f, mask);
    }
    //va cham duoi
    private bool isGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 1f, mask);
    }

    public void reRotateBySword()
    {
        die_trap = true;
        die_sword = false;
    }


    void SetColl()
    {
        die_frozen = true;
        die_sword = false;
    }
}
