using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class HighScore : MonoBehaviour
{

    public string savePath;
    public string textFromFile;
    public string filePath;
    private string highScoreFilePath;
    public TMP_Text messageText;


    void Start()
    {
        
        highScoreFilePath = Path.Combine(Application.persistentDataPath, "HighScore.txt");
        if(!File.Exists(highScoreFilePath))
        {
            File.WriteAllText(highScoreFilePath, "0");
        }

        string selectedSaveFileName = File.ReadAllText(getPath());
        filePath = Path.Combine(Application.persistentDataPath, selectedSaveFileName);
        string json = File.ReadAllText(filePath);
        JSONReader.StatsList statsList = JsonUtility.FromJson<JSONReader.StatsList>(json);
        string PreviousHS = File.ReadAllText(highScoreFilePath);
        int PHS = int.Parse(PreviousHS);
        if (statsList.stats[2].scr >= PHS)
        {
            int Score = statsList.stats[2].scr;
            File.WriteAllText(highScoreFilePath, Score.ToString());
            messageText.SetText(Score.ToString());
        }
        else
        {
            messageText.SetText(PreviousHS);
        }


    }

    public string getPath()
    {
        savePath = Path.Combine(Application.persistentDataPath, "SaveSelection.txt");
        return savePath;
    }
}
