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
    private string ScoreFilePath;
    public TMP_Text messageText;


    void Start()
    {
        highScoreFilePath = Path.Combine(Application.persistentDataPath, "HighScore");
        Directory.CreateDirectory(highScoreFilePath);
        highScoreFilePath = Path.Combine(highScoreFilePath, "highscore.txt");

        if (!File.Exists(highScoreFilePath))
        {
            messageText.text = "0";
        }
        else
        {
            StreamReader sr = new StreamReader(highScoreFilePath);
            string highscore = sr.ReadLine();
            messageText.text = highscore;
            sr.Close();
        }

        /*ScoreFilePath = Path.Combine(Application.persistentDataPath, "Score.txt");
        highScoreFilePath = Path.Combine(Application.persistentDataPath, "HighScore.txt");
        if (!File.Exists(highScoreFilePath))
        {
            File.WriteAllText(highScoreFilePath, "0");
        }



        string selectedSaveFileName = File.ReadAllText(getPath());
        filePath = Path.Combine(Application.persistentDataPath, selectedSaveFileName);
        string json = File.ReadAllText(filePath);
        JSONReader.StatsList statsList = JsonUtility.FromJson<JSONReader.StatsList>(json);
        string PreviousHS = File.ReadAllText(highScoreFilePath);
        string currentScore = File.ReadAllText(ScoreFilePath);
        int PHS = int.Parse(PreviousHS);
        int CS = int.Parse(currentScore);
        if (CS >= PHS)
        {
            int Score = CS;
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
    }*/
    }
}
