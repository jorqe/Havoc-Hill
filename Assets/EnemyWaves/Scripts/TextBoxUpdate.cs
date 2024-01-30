
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class TextBoxUpdate : MonoBehaviour
{
    [SerializeField]
    private TMP_Text displayText;
    string[] lines;
    public TextAsset lessonFile;

    // Start is called before the first frame update
    void Start()
    {
        lines = lessonFile.text.Split('\n'); // Split the text into lines
    }
    public void DisplayRandomTrivia()
    {
        if (lines != null && lines.Length > 0)
        {
            int index = Random.Range(0, lines.Length); // Pick a random line
            int lmod = (index % 2); //Text file starts with a question, then it's answer, alternating
            if (lmod == 1)
            {
                index++;
            }
            string trivia_bit = lines[index];
            // Display trivia/lesson on the screen using UI Text
            displayText.text = trivia_bit;
        }
    }
}
