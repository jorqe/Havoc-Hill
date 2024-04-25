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

    void Start()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "JsonText.txt");
        string filePath1 = Path.Combine(Application.persistentDataPath, "JsonText1.txt");
        string filePath2 = Path.Combine(Application.persistentDataPath, "JsonText2.txt");

        if (!File.Exists(filePath))
        {
            Yas = "No file existing";
            saver.deathSave();
        }
        else if(File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            JSONReader.StatsList statsList = JsonUtility.FromJson<JSONReader.StatsList>(json);
            if (statsList.stats.Length > 0 && statsList.stats[0].ph <= 0)
            {
                // Call DeathSave() from JSONWriter
                saver.deathSave();
            }
        }

        if (!File.Exists(filePath1))
        {
            Yas = "No file existing";
            saver.deathSave();
        }
        else if (File.Exists(filePath1))
        {
            string json = File.ReadAllText(filePath1);
            JSONReader.StatsList statsList = JsonUtility.FromJson<JSONReader.StatsList>(json);
            if (statsList.stats.Length > 0 && statsList.stats[0].ph <= 0)
            {
                // Call DeathSave() from JSONWriter
                saver.deathSave();
            }
        }

        if (!File.Exists(filePath2))
        {
            Yas = "No file existing";
            saver.deathSave();
        }
        else if (File.Exists(filePath2))
        {
            string json = File.ReadAllText(filePath2);
            JSONReader.StatsList statsList = JsonUtility.FromJson<JSONReader.StatsList>(json);
            if (statsList.stats.Length > 0 && statsList.stats[0].ph <= 0)
            {
                // Call DeathSave() from JSONWriter
                saver.deathSave();
            }
        }

    }

    void Update()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "JsonText.txt");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            messageText.SetText(json);

        }
        else
        {
            messageText.SetText(Yas);
        }
            
    }
}
