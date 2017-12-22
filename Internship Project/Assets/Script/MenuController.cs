using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    private PlayerProgress playerProgress;

	public void StartGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    
}
