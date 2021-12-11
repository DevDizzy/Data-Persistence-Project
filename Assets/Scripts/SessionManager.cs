using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SessionManager : MonoBehaviour
{
    public static SessionManager Instance;
    public string highScoreText = "Play to get best score!";

    [HideInInspector]
    public int highScore;
    public string highScorerName;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.scorerName = highScorerName;

        string json = JsonUtility.ToJson(data);
        string saveFileLocation = Application.persistentDataPath + "/highscore.json";
        Debug.Log("Saving file to:" + saveFileLocation);
        Debug.Log("Saving Scorer Name: " + highScorerName);

        File.WriteAllText(saveFileLocation, json);
    }

    public void LoadScore()
    {
        string saveFileLocation = Application.persistentDataPath + "/highscore.json";

        if (File.Exists(saveFileLocation))
        {
            string json = File.ReadAllText(saveFileLocation);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScorerName = data.scorerName;

            highScoreText = "Best Score "+ highScorerName + ": " + highScore;
        }
    }
}

[System.Serializable]
class SaveData
{
    public int highScore;
    public string scorerName;
}
