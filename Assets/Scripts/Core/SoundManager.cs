using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance{get; private set;}

    private AudioSource SFXsound;

    private void Awake()
    {
        instance = this;
        SFXsound = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound)
    {
        SFXsound.PlayOneShot(sound);
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class AudioManager : MonoBehaviour
// {
//     [Header("-----------Audio Source------------")]
//     [SerializeField] AudioSource musicSource;

//     [Header("-----------Audio Clip------------")]
//     public AudioClip MainBackgroundMusic;

//     // Start is called before the first frame update
//     void Start()
//     {
//         musicSource.clip = MainBackgroundMusic;
//         musicSource.Play();
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }