using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----- Audio Source -----")]
    [SerializeField] public AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] public AudioSource SFXRun;

    [Header("----- Audio SFX -----")]
    public AudioClip background;
    public AudioClip arrow;
    public AudioClip iceBullet;
    public AudioClip sword;
    public AudioClip jump;
    public AudioClip hit;
    public AudioClip run;

    public static AudioManager instance;

    private void Awake()
    {
        //instance = this;       
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    
    

}
