using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SwapPlayer : MonoBehaviour
{

    public GameObject[] pl;

    public GameObject currenPlayer;

    private int activeCharacterIndex = 0;

    public bool player1Active = true;
    public bool player2Active = false;
    public bool player3Active = false;
 
    void Update()
    {
        //nv hien tai chet thi chuyen sang nv tiep theo
        if (pl[activeCharacterIndex].GetComponent<PlayerLife>().currentState == PlayerLife.CharacterState.Dead)
        {
            pl[activeCharacterIndex].GetComponent<movement>().enabled = false;
            activeCharacterIndex = (activeCharacterIndex + 1) % pl.Length;
            pl[activeCharacterIndex].GetComponent<movement>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            
            PlayerSwap();
            
            Debug.Log("aa");
        }
        currenPlayer = pl[activeCharacterIndex];
        afterPlayerSwap();
        

    }

    private void FixedUpdate()
    {
        GameOver();
    }

    //ham doi nhan vat
    public void PlayerSwap()
    {
        if (pl[activeCharacterIndex].GetComponent<PlayerLife>().currentState == PlayerLife.CharacterState.Alive)
        {
            //vo hieu hoa nv
            pl[activeCharacterIndex].GetComponent<movement>().enabled = false;

            //di chuyen den nhan vat tiep theo trong mang neu con song
            int nexCharacterIndex = (activeCharacterIndex + 1) % pl.Length;
            while (pl[nexCharacterIndex].GetComponent<PlayerLife>().currentState != PlayerLife.CharacterState.Alive)
            {
                nexCharacterIndex = (nexCharacterIndex + 1) % pl.Length ;
            }

            activeCharacterIndex = nexCharacterIndex;

            pl[activeCharacterIndex].GetComponent<movement>().enabled = true ;
            //currenPlayer = pl[activeCharacterIndex];
        }
    }

    public void afterPlayerSwap()
    {
        if (pl[0].GetComponent<movement>().enabled == false)
        {
            pl[0].GetComponent<UpdateAnim>().enabled = true;
        }
        else
        {
            pl[0].GetComponent<UpdateAnim>().enabled = false;
        }
        if (pl[1].GetComponent<movement>().enabled == false)
        {
            pl[1].GetComponent<UpdateAnim>().enabled = true;
        }
        else
        {
            pl[1].GetComponent<UpdateAnim>().enabled = false;
        }
        if (pl[2].GetComponent<movement>().enabled == false)
        {
            pl[2].GetComponent<UpdateAnim>().enabled = true;
        }
        else
        {
            pl[2].GetComponent<UpdateAnim>().enabled = false;
        }
    }
   
    public void GameOver()
    {
        
        if (pl[0].GetComponent<PlayerLife>().currentState == PlayerLife.CharacterState.Dead && pl[1].GetComponent<PlayerLife>().currentState == PlayerLife.CharacterState.Dead && pl[2].GetComponent<PlayerLife>().currentState == PlayerLife.CharacterState.Dead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }       
    }
}
