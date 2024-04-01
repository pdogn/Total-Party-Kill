using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapWeapon : MonoBehaviour
{
    public GameObject[] player;

    
    // Update is called once per frame
    void Update()
    {
        if (player[0].GetComponent<movement>().enabled == true)
        {
            player[0].GetComponentInChildren<Shotting>().enabled = true;
        }
        else
        {
            player[0].GetComponentInChildren<Shotting>().enabled = false;
        }

        if (player[1].GetComponent<movement>().enabled == true)
        {
            player[1].GetComponentInChildren<AttackArea>().enabled = true;
        }
        else
        {
            player[1].GetComponentInChildren<AttackArea>().enabled = false;
        }

        if (player[2].GetComponent<movement>().enabled == true)
        {
            player[2].GetComponentInChildren<Shotting>().enabled = true;
        }
        else
        {
            player[2].GetComponentInChildren<Shotting>().enabled = false;
        }
    }
}
