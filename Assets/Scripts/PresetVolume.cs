using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PresetVolume : MonoBehaviour
{

    public AudioMixer audio;
    // Start is called before the first frame update
    void Start()
    {
        audio.SetFloat("masterVolume",PlayerPrefs.GetFloat("masterVolume"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
