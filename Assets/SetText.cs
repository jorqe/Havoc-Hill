using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
public class SetText : MonoBehaviour
{
    public TMP_Text messageText;
    public JSONWriter saver;
    public string Yas;
    public SaveSelection Select;
    public string savePath;
    public string filePath;
    public string textFromFile;

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "JsonText.txt");
        string filePath1 = Path.Combine(Application.persistentDataPath, "JsonText1.txt");
        string filePath2 = Path.Combine(Application.persistentDataPath, "JsonText2.txt");
        string demoPath = Path.Combine(Application.persistentDataPath, "DemoText.txt");
        

        savePath = Path.Combine(Application.persistentDataPath, "SaveSelection.txt");

        if (!File.Exists(filePath1))
        {
            File.WriteAllText(savePath, "JsonText1.txt");
            saver.filePath = Path.Combine(Application.persistentDataPath, "JsonText1.txt");
            saver.deathSave();

            File.WriteAllText(savePath, "JsonText2.txt");
            saver.filePath = Path.Combine(Application.persistentDataPath, "JsonText2.txt");
            saver.deathSave();

            File.WriteAllText(savePath, "DemoText.txt");
            saver.filePath = Path.Combine(Application.persistentDataPath, "DemoText.txt");
            saver.DemoSave();
        }


        if (File.Exists(filePath1))
        {
            string json = File.ReadAllText(filePath1);
            JSONReader.StatsList statsList = JsonUtility.FromJson<JSONReader.StatsList>(json);
            if (statsList.stats[0].ph <= 0)
            {
                File.WriteAllText(savePath, "JsonText1.txt");
                saver.filePath = Path.Combine(Application.persistentDataPath, "JsonText1.txt");
                saver.deathSave();
            }
        }

        if (File.Exists(filePath2))
        {
            string json = File.ReadAllText(filePath2);
            JSONReader.StatsList statsList = JsonUtility.FromJson<JSONReader.StatsList>(json);
            if (statsList.stats[0].ph <= 0)
            {
                File.WriteAllText(savePath, "JsonText2.txt");
                saver.filePath = Path.Combine(Application.persistentDataPath, "JsonText2.txt");
                saver.deathSave();
            }
        }

        if (File.Exists(demoPath))
        {
            string json = File.ReadAllText(demoPath);
            JSONReader.StatsList statsList = JsonUtility.FromJson<JSONReader.StatsList>(json);
            if (statsList.stats[0].ph <= 0)
            {
                File.WriteAllText(savePath, "DemoText.txt");
                saver.filePath = Path.Combine(Application.persistentDataPath, "DemoText.txt");
                saver.DemoSave();
            }
        }


    }




    public string getPath()
    {
        savePath = Path.Combine(Application.persistentDataPath, "SaveSelection.txt");
        return savePath;
    }


    void Update()
    {


        if (File.Exists(getPath()))
        {
            string selectedSaveFileName = File.ReadAllText(getPath());
            filePath = Path.Combine(Application.persistentDataPath, selectedSaveFileName);

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                JSONReader.StatsList statsList = JsonUtility.FromJson<JSONReader.StatsList>(json);
                if (statsList != null && statsList.stats.Length > 0)
                {
                    JSONReader.Stats firstStat = statsList.stats[0];
                    string displayText = $"Player Health: {firstStat.ph}\n" +
                                         $"Max Health: {firstStat.mH}\n" +
                                         $"Bullet Damage: {firstStat.bD}\n" +
                                         $"Bullet Speed: {firstStat.bS}\n" +
                                         $"Fire Rate: {firstStat.fR}\n" +
                                         $"Critical Chance: {firstStat.cc}\n" +
                                         $"Difficulty: {firstStat.dif}\n" +
                                         $"Wave Number: {firstStat.wave}";
                    messageText.SetText(displayText);
                }
                else
                {
                    messageText.SetText("Data in save file is invalid or empty.");
                }
            }
            else
            {
                messageText.SetText("Save file not found.");
            }
        }
        else
        {
            messageText.SetText("No Save Selected");
        }
    }
}
