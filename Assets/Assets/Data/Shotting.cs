using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shotting : MonoBehaviour
{
    public GameObject bullet;
    
    float speed = 1100;
//
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            DD();
            this.GetComponentInParent<movement>().anim.SetTrigger("attack");
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            if(GetComponentInParent<movement>().isFacingRight == true)
                newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
            else
                newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed);

            Destroy(newBullet,3f);
        }
        
    }

    void DD()
    {
        if(this.gameObject.GetComponent<Shotting>().enabled == true && this.gameObject.name.Equals("bulletPos"))
        {
            Debug.Log("ban bang");;
            AudioManager.instance.PlaySFX(AudioManager.instance.iceBullet);
            
        }
        if (this.gameObject.GetComponent<Shotting>().enabled == true && this.gameObject.name.Equals("arrowPos"))
        {
            Debug.Log("ban ten");
            AudioManager.instance.PlaySFX(AudioManager.instance.arrow);
        }
    }
    
}
