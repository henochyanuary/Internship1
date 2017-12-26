using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonManager : MonoBehaviour {

    private List<GameObject> levelButtonList = new List<GameObject>();
    private DataController dataController;

    public AnswerButtonPool buttonPool;
    public Transform parentPanel;

	// Use this for initialization
	void Start () {

        dataController = FindObjectOfType<DataController>();
        
        ShowLevel();
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void ShowLevel()
    {
        for (int i = 0; i<dataController.GetUnlockedLevel(); i++)
        {
            GameObject levelButtonGO = buttonPool.GetObject();
            levelButtonGO.transform.SetParent(parentPanel);
            levelButtonList.Add(levelButtonGO);

            LevelButton levelButton = levelButtonGO.GetComponent<LevelButton>();

            levelButton.levelText.text = "Level " + (i + 1);

            levelButton.levelData = i;

        }
    }

}
