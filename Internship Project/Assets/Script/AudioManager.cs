using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class AudioManager : MonoBehaviour {

    public AudioSource generalAudioSource;
    public List<AudioClip> audioClips = new List<AudioClip>();
    public List<AudioClip> sfxClips = new List<AudioClip>();

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        generalAudioSource = GetComponent<AudioSource>();
        
	}
}
