using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ice_bullet_script : MonoBehaviour
{
    public CameraShake cameraShake;

    private void Start()
    {
        cameraShake = GameObject.FindObjectOfType<CameraShake>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ground" || collision.tag == "player")
        {
            Destroy(gameObject, .01f);
        } 
        
        if(collision.gameObject.tag == "player" && collision.gameObject.GetComponent<Die_Anim>().die_frozen == false)
        {
            cameraShake.ShakeCamera();
        }

        if (collision.gameObject.tag == "atkArea" && collision.gameObject.GetComponentInParent<Die_Anim>().die_frozen == false)
        {
            cameraShake.ShakeCamera();
        }
    }
}
