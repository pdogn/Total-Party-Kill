using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn : MonoBehaviour
{
    Animator anim;
    public bool btnDowned;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player")
        {
            anim.SetTrigger("btndown");
            btnDowned = true;
        }
    }
}
