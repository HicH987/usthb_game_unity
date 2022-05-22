using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource audio_src1; // Creates a static varible for a MusicControlScript instance
    public static BackgroundMusic instance; // Creates a static varible for a MusicControlScript instance
    
    // public void PlaySoundButton1()
    // {
    //     audio_src1.Play();
    // }

    // private void Awake() // Runs before void Start()
    // {
    //     DontDestroyOnLoad(this.gameObject); // Don't destroy this gameObject when loading different scenes

    //     if (instance == null) // If the MusicControlScript instance variable is null
    //     {
    //         instance = this; // Set this object as the instance
    //     }
    //     else // If there is already a MusicControlScript instance active
    //     {
    //         Destroy(gameObject); // Destroy this gameObject
    //     }
    // }
}