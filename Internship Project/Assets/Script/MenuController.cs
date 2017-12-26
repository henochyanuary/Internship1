using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour {

    private PlayerProgress playerProgress;
    public AudioManager audioManager;

    public GameObject creditPanel;
    public GameObject frontPanel;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

	public void StartGame()
    {
        SceneManager.LoadScene("LevelSelect");
        audioManager.generalAudioSource.PlayOneShot(audioManager.sfxClips[0],2.0f);
    }

    public void ShowCredit()
    {
        creditPanel.SetActive(true);
        frontPanel.SetActive(false);
    }
    public void CloseCrdit()
    {
        creditPanel.SetActive(false);
        frontPanel.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    
}
