using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerICE : MonoBehaviour
{
    bool fl;
    public Transform tg;
    Vector3 ob;

    private void Update()
    {
        //khi nv dung tren cuc bang thi set parent cho nv
        if (fl == true)
        {
            ob = transform.position;
            ob.x = tg.position.x;
            transform.position = new Vector3(ob.x, ob.y, ob.z);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "head" && collision.gameObject.GetComponentInParent<Die_Anim>().die_frozen == true)
        {
            fl = true;
            tg = collision.transform;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player" && collision.gameObject.GetComponent<Die_Anim>().die_frozen == true)
        {
            fl = false;

        }
    }

   
}
