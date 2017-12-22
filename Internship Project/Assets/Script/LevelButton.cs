using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour {

    public Text levelText;
    public int levelData;
    private DataController dataControler;

    void Start()
    {
        dataControler = FindObjectOfType<DataController>();
    }

	public void GetLevel()
    {
        dataControler.numberLevel = levelData;
        SceneManager.LoadScene("Game");
    }
}
