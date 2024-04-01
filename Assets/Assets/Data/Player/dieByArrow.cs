using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieByArrow : MonoBehaviour
{
    
    public movement yellow;
    public Vector3 aa;
    bool trungten = false;

    bool isRight;
    void Awake()
    {
        aa = transform.localScale;       
        
        //bb =  yellow.localScale;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            isRight = yellow.isFacingRight;
        }
        if(trungten && isRight == true && gameObject.GetComponent<Die_Anim>().die_frozen == false)
        {
            transform.localScale = new Vector3 (aa.x, aa.y, aa.z);
            
        }
        if(trungten && isRight==false && gameObject.GetComponent<Die_Anim>().die_frozen == false)
        {
            transform.localScale = new Vector3(-aa.x, aa.y, aa.z);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player" && this.gameObject.GetComponent<PlayerLife>().currentState == PlayerLife.CharacterState.Dead && this.gameObject.GetComponent<Die_Anim>().Die_arrow == true)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().drag = 60;
        }

        if(collision.gameObject.tag == "arrow")
        {
            trungten = true;
            
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().drag = 0;
        }

        if (collision.gameObject.tag == "arrow")
        {
            trungten = false;
            
        }
    }
}
