using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Variable para mantener el manager entre escenas
    public static SoundManager instance; 
    //El static permite referenciar a la misma clase, en este caso SoundManager
    
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSrc;
    [SerializeField] AudioSource sfxSrc;
    [SerializeField] AudioSource backgrdSrc;

    [Header("Audio Clips")]
    public AudioClip music;
    public AudioClip bckgrd;
    public AudioClip jump;

    void Awake()
    {
        //Código para que la instancia del Sound Manager no se repita por error
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
    
    void Start()
    {
        musicSrc.clip = music;
        musicSrc.Play();

        backgrdSrc.clip = bckgrd;
        backgrdSrc.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSrc.PlayOneShot(clip);
    }

}
