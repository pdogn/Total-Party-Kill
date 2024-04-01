using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    public GameObject yellow;
   
    Vector3 cc,dd;
    bool trungten;
    // Start is called before the first frame update
    void Start()
    {
        yellow = GameObject.Find("yellow");
        cc = transform.localScale;
        //cc.x = transform.localScale.x;
        //cc.x = transform.localScale.y;
        //cc.x = transform.localScale.z;

        dd = yellow.transform.localScale;
    }

    private void Update()
    {
        //if(yellow.GetComponent<movement>().isFacingRight == false)
        //{
        //    transform.localScale = new Vector3(-cc.x, cc.y, cc.z);           
        //}
        //else
        //{
        //    transform.localScale = new Vector3(cc.x, cc.y, cc.z);
        //}

        if (dd.x < 0)
        {
            transform.localScale = new Vector3(-cc.x, cc.y, cc.z);
           
                
              
            
        }
        else if(dd.x > 0)
        {
            transform.localScale = new Vector3(cc.x, cc.y, cc.z);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().drag = 0;
        }       
        Destroy(gameObject, .01f);
    }
}
