using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;



public class H_Scale : MonoBehaviour {
    public JSONWriter saver;
    public PlayerStatsScriptableObject playerStatsScriptable;

    public string savePath;
    public string filePath;
    private string highscorePath;


    void Start()
    {
        transform.localScale = new Vector3(1.0f, 0.5f, 0.25f);
        getPath();
    }

    public string getPath()
    {
        savePath = Path.Combine(Application.persistentDataPath, "SaveSelection.txt");
        string textFromFile = File.ReadAllText(savePath);
        filePath = Path.Combine(Application.persistentDataPath, textFromFile);
        return filePath;
    }

    // Update is called once per frame
    void Update()
    {

            float ph = playerStatsScriptable.currentHealth;
            float mh = playerStatsScriptable.maxHealth;
            float x = ph/mh;
            if(x > 0f)
            {
                transform.localScale = new Vector3(x, 0.5f, 0.25f);
            }
            else
            {
                transform.localScale = new Vector3(0.0f, 0.5f, 0.25f);
            }



        if (playerStatsScriptable.currentHealth <= 0f)
        {
            highscorePath = Path.Combine(Application.persistentDataPath, "HighScore");
            Directory.CreateDirectory(highscorePath);
            highscorePath = Path.Combine(highscorePath, "highscore.txt");
            if (!File.Exists(highscorePath))
            {
                StreamWriter sw = new StreamWriter(highscorePath);
                sw.WriteLine(playerStatsScriptable.score);
                sw.Close();
            }
            else
            {
                StreamReader sr = new StreamReader(highscorePath);
                int highscore = int.Parse(sr.ReadLine());
                sr.Close();
                if (playerStatsScriptable.score > highscore)
                {
                    StreamWriter sw = new StreamWriter(highscorePath);
                    sw.WriteLine(playerStatsScriptable.score);
                    sw.Close();
                }

            }

            File.Delete(getPath());
            SceneManager.LoadScene(0);
        }

    }
}