using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnDown : MonoBehaviour
{
    Animator anim;
    [SerializeField] protected bool downed;
    [SerializeField] Transform rollDoor;
    [SerializeField] Transform point;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (downed)
        {
            rollDoor.position = Vector3.MoveTowards(rollDoor.position, point.position, 5 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player")
        {
            anim.SetTrigger("btndown");
            downed = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(point.position, rollDoor.position);
    }
}
