using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
public class SetText : MonoBehaviour
{
    public TMP_Text messageText;

    void Update()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "JsonText.txt");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            //MessageData data = JsonUtility.FromJson<MessageData>(json);
            messageText.SetText(json);
        }
        else
        {
            messageText.SetText("No Save Data");
        }
            
    }
}
