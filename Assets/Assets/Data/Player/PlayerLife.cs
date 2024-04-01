using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    //protected static PlayerLife instance;
    //public static PlayerLife Instance { get { return instance; } }
    public enum CharacterState
    {
        Alive,
        Dead
    }
    public CharacterState currentState;
    public CameraShake cameraShake;
    void Start()
    {
        // Gán tr?ng thái ban ??u là s?ng
        currentState = CharacterState.Alive;
        cameraShake = GameObject.FindObjectOfType<CameraShake>();
    }

    // Ph??ng th?c này ??i di?n cho vi?c x? lí khi nhân v?t b? ch?t
    public void Die()
    {
        // Gán tr?ng thái là ch?t
        currentState = CharacterState.Dead;
        // X? lí các tác ??ng khác khi nhân v?t ch?t, nh? phát hi?n va ch?m, chuy?n ??i animation, hi?n th? thông báo màn ch?i k?t thúc, v.v.
        //...
    }

    void ShakeCam()
    {
        cameraShake.ShakeCamera();
    }
}
