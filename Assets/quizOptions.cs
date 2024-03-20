using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class quizOptions : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        var quizzes = Directory.EnumerateFiles(Application.persistentDataPath, "*.txt");

        foreach (string quiz in quizzes){
            dropdown.options.Add(new TMP_Dropdown.OptionData(quiz.Substring(Application.persistentDataPath.Length+1), null));
            Debug.Log("quiz = " + quiz.Substring(Application.persistentDataPath.Length+1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable(){
        Debug.Log("quiz chosen is " + dropdown.options[dropdown.value].text);
        PlayerPrefs.SetString("quiz", dropdown.options[dropdown.value].text);
    }
}
