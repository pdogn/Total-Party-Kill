using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Player : MonoBehaviour
{
    [SerializeField] Sprite bl;
    [SerializeField] Sprite gr;
    [SerializeField] Sprite yl;

    SwapPlayer player;
    Image Img;
    
    void Start()
    {
        player = GameObject.FindObjectOfType<SwapPlayer>();
        Img = GetComponent<Image>();
    }

    
    void Update()
    {
        if(player.currenPlayer == player.pl[0])
        {
            Img.sprite = bl;
        }
        if (player.currenPlayer == player.pl[1])
        {
            Img.sprite = gr;
        }
        if (player.currenPlayer == player.pl[2])
        {
            Img.sprite = yl;
        }
    }
}
