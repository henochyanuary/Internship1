using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class DataController : MonoBehaviour {

    public int numberLevel;
    public int unlockedLevel;
    public List<string> nameButton = new List<string>();

    private PlayerProgress playerProgress;
    private RoundData[] allRoundData;

    private string gameDataFileName = "data.json";
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject); // make this object stays in the game at all time, unless deleted 
        LoadPlayerProgress();
        LoadUnlockedLevel();
        LoadGameData();
        SceneManager.LoadScene("Main");
        unlockedLevel = GetUnlockedLevel();

        // deleting existing player prefs on build
        if(!Application.isEditor)
        {
            PlayerPrefs.DeleteAll();
        }
	}

    public RoundData GetCurrentRoundData()
    {
        // put code to change round here
        return allRoundData[numberLevel];
    }

    public void SubmitNewPlayerScore(int newScore)
    {
        if(newScore>playerProgress.highestScore)
        {
            playerProgress.highestScore = newScore;
            SavePlayerProgress();
        }
    }
    public void SubmitUnlockedLevel(int levelUnlocked)
    {
        playerProgress.unlockedLevel = levelUnlocked;
        SaveUnlockedLevel();
    }

    public int GetHighestPlayerScore()
    {
        return playerProgress.highestScore;
    }
    
    public int GetUnlockedLevel()
    {
        return playerProgress.unlockedLevel;
    }
	
	private void LoadPlayerProgress()
    { 
        playerProgress = new PlayerProgress();

        if (PlayerPrefs.HasKey("highestScore"))
        {
            playerProgress.highestScore = PlayerPrefs.GetInt("highestScore");
        }
    }

    private void SavePlayerProgress()
    {
        PlayerPrefs.SetInt("highestScore", playerProgress.highestScore);
    }

    private void LoadUnlockedLevel()
    {
        playerProgress = new PlayerProgress();

        if (PlayerPrefs.HasKey("unlockedLevel"))
        {
            playerProgress.unlockedLevel = PlayerPrefs.GetInt("unlockedLevel");
        }
    }

    private void SaveUnlockedLevel()
    {
        PlayerPrefs.SetInt("unlockedLevel", playerProgress.unlockedLevel);
    }

    private void LoadGameData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
        if(File.Exists(filePath))
        {
            string dataAsJSON = File.ReadAllText(filePath);
            GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJSON);

            allRoundData = loadedData.allRoundData;
            
        }
        else
        {
            Debug.LogError("File is not found!!");
        }
    }
}
