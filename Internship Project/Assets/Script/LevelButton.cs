using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour {

    public Text levelText;
    public int levelData;
    private DataController dataControler;
    private AudioManager audioManager;
   

    void Start()
    {
        dataControler = FindObjectOfType<DataController>();
        audioManager = FindObjectOfType<AudioManager>();
    }

	public void GetLevel()
    {
        dataControler.numberLevel = levelData;
        SceneManager.LoadScene("Game");
        audioManager.generalAudioSource.PlayOneShot(audioManager.sfxClips[0],2.0f);
    }
    
}
