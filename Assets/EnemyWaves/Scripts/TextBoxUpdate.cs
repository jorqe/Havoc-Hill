
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.IO;
public class TextBoxUpdate : MonoBehaviour
{
    [SerializeField]
    private TMP_Text displayText;
    private string quizFileName;
    string[] lines;
    int answer;
    public TextAsset lessonFile;

    // Start is called before the first frame update
    void Start()
    {
        quizFileName = @"/" + PlayerPrefs.GetString("quiz");
        lessonFile = new TextAsset(File.ReadAllText(Application.persistentDataPath+quizFileName));
        lines = lessonFile.text.Split('\n'); // Split the text into lines
        Debug.Log("first line is " + lines[0]);
    }
    public void DisplayRandomTrivia()
    {
        if (lines != null && lines.Length > 0)
        {
            int index = Random.Range(0, lines.Length); // Pick a random line
            Debug.Log("Index = " + index);
            int lmod = (index % 3); //Text file starts with a hint, the question, then it's answer, alternating
            if (lmod == 0)
            {
                Debug.Log("lmod = " + lmod);
                answer = index + 2;
                index++;
            }
            else if (lmod == 2)
            {
                Debug.Log("lmod = " + lmod);
                answer = index;
                index--;
            }
            else
            {
                answer = index + 1;
            }

            Debug.Log("answer = " + lines[answer]);
            Debug.Log("new Index = " + index);
            string trivia_bit = lines[index];
            // Display trivia/lesson on the screen using UI Text
            displayText.text = trivia_bit;
        }
    }

    public string getAnswer()
    {
        return lines[answer];
    }
}
