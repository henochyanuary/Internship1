using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonManager : MonoBehaviour {

    private List<GameObject> levelButtonList = new List<GameObject>();

    public AnswerButtonPool buttonPool;
    public Transform parentPanel;

	// Use this for initialization
	void Start () {

        ShowLevel();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void ShowLevel()
    {
        for (int i = 0; i<10; i++)
        {
            GameObject levelButtonGO = buttonPool.GetObject();
            levelButtonGO.transform.SetParent(parentPanel);
            levelButtonList.Add(levelButtonGO);

            LevelButton levelButton = levelButtonGO.GetComponent<LevelButton>();
            int newI = i + 1;
            levelButton.levelText.text = "Level " + newI.ToString();

            levelButton.levelData = i;

        }
    }
}
