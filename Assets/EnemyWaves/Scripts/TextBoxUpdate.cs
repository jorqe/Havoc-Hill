
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class TextBoxUpdate : MonoBehaviour
{
    [SerializeField]
    private TMP_Text displayText;
    string[] lines;
    int answer;
    public TextAsset lessonFile;
    public string input;

    // Start is called before the first frame update
    void Start()
    {
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

    public string setInput(string given)
    {
        if (given == "true")
        {
            input = "true";
        }

        if (given == "false")
        {
            input = "false";
        }
        return input;
    }

    public string getInput()
    {
        return input;

    }
}
