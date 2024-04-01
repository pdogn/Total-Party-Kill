using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    //Animator anim;
    public bool allowAttack;

    private GameObject bl, yl;
    bool p1,p2,right;

    public float vtu = 300, vtr = 200;

//
    void Update()
    {
        if(this.GetComponentInParent<movement>().isFacingRight == true)
        {
            right = true;
        }
        else
        {
            right = false;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            GameObject x = GameObject.Find("attackArea");
            if (x.GetComponent<AttackArea>().enabled == true)
            {
                AudioManager.instance.PlaySFX(AudioManager.instance.sword);
            }
            atk();
        }
        
       

    }
    void atk()
    {
        this.GetComponentInParent<movement>().anim.SetTrigger("attack");
        //bl.GetComponent<Die_Anim>().Die_sw = true;
        if (allowAttack && p1)
        {
            bl.GetComponent<Die_Anim>().Die_sw = true;

            bl.GetComponent<Die_Anim>().die_frozen = false;
            bl.GetComponent<Die_Anim>().die_trap = false;
            bl.GetComponent<Die_Anim>().die_arrow = false;
            bl.GetComponent<Rigidbody2D>().AddForce(Vector2.up * vtu);
            if (right == true)
            {
                
                bl.transform.localScale = new Vector3(1, 1, 1);
                bl.GetComponent<Rigidbody2D>().AddForce(Vector2.right * vtr, ForceMode2D.Force);
                //bl.GetComponent<Rigidbody2D>().drag = 5;

            }
            else
            {
                bl.transform.localScale = new Vector3(-1, 1, 1);
                bl.GetComponent<Rigidbody2D>().AddForce(Vector2.right * -vtr, ForceMode2D.Force);
                //bl.GetComponent<Rigidbody2D>().drag = 5;
            }
            
        }
        if (allowAttack && p2)
        {
            yl.GetComponent<Die_Anim>().Die_sw = true;

            yl.GetComponent<Die_Anim>().die_frozen = false;
            yl.GetComponent<Die_Anim>().die_trap = false;
            yl.GetComponent<Die_Anim>().die_arrow = false;
            yl.GetComponent<Rigidbody2D>().AddForce(Vector2.up * vtu);
            if (right == true)
            {
                yl.transform.localScale = new Vector3(1, 1, 1);
                yl.GetComponent<Rigidbody2D>().AddForce(Vector2.right * vtr, ForceMode2D.Force);
                //yl.GetComponent<Rigidbody2D>().drag = 5;
            }
            else
            {
                yl.transform.localScale = new Vector3(-1, 1, 1);
                yl.GetComponent<Rigidbody2D>().AddForce(Vector2.right * -vtr, ForceMode2D.Force);
                //yl.GetComponent<Rigidbody2D>().drag = 5;
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            allowAttack = true;
        }
        if(collision.name == "blue")
        {
            bl = collision.gameObject;
            p1 = true;
        }
        if (collision.name == "yellow")
        {
            yl = collision.gameObject;
            p2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            allowAttack = false;
        }
        if (collision.name == "blue")
        {
            
            p1 = false;
        }
        if (collision.name == "yellow")
        {
            
            p2 = false;
        }
    }
}
