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
        // G�n tr?ng th�i ban ??u l� s?ng
        currentState = CharacterState.Alive;
        cameraShake = GameObject.FindObjectOfType<CameraShake>();
    }

    // Ph??ng th?c n�y ??i di?n cho vi?c x? l� khi nh�n v?t b? ch?t
    public void Die()
    {
        // G�n tr?ng th�i l� ch?t
        currentState = CharacterState.Dead;
        // X? l� c�c t�c ??ng kh�c khi nh�n v?t ch?t, nh? ph�t hi?n va ch?m, chuy?n ??i animation, hi?n th? th�ng b�o m�n ch?i k?t th�c, v.v.
        //...
    }

    void ShakeCam()
    {
        cameraShake.ShakeCamera();
    }
}
