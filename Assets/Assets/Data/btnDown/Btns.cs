using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btns : MonoBehaviour
{
    [SerializeField] protected GameObject btn1, btn2;
    [SerializeField] protected Transform roolDoor;
    [SerializeField] protected Transform pointTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(btn1.GetComponent<Btn>().btnDowned == true && btn2.GetComponent<Btn>().btnDowned == true)
        {
            roolDoor.position = Vector3.MoveTowards(roolDoor.position, pointTarget.position, 5 * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(roolDoor.position, pointTarget.position);
    }
}
