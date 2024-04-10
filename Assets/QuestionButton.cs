using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class QuestionButton : MonoBehaviour
{
    public string buttonValue;
    public GameObject press;
    public GameObject questionInterface;
    public TextBoxUpdate textBoxUpdate;
    public TriviaInputScriptableObject triviaInputScriptable;
    public string current_answer;
    bool isPressed;
    GameObject presser;
    string buttonName;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
        buttonName = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        if (!isPressed){
            press.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            //onPress.Invoke();
            isPressed = true;
            
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.gameObject == presser){
            press.transform.localPosition = new Vector3(0, 0.015f, 0);
            //Debug.Log("Type of buttonName is " + buttonName.GetType());
            //Debug.Log("Type of textBoxUpdate.getAnswer is " + textBoxUpdate.getAnswer().GetType());
            Debug.Log("buttonValue is " + buttonValue);
            Debug.Log("in questionbutton answer = " + textBoxUpdate.getAnswer());
            current_answer = textBoxUpdate.getAnswer().TrimEnd(new char[] { '\r', '\n' });
            Debug.Log("current_answer is " + current_answer);
            Debug.Log("comparison of " + buttonValue + " and " + current_answer + " is " + (buttonValue.Equals(current_answer, StringComparison.Ordinal)));

            string buttonValue_ar = string.Join(",", buttonValue.ToCharArray().Select(s => (int)s));
            string current_ar = string.Join(",", current_answer.ToCharArray().Select(s => (int)s));
            Debug.Log("buttonValue_ar is " + buttonValue_ar);
            Debug.Log("current_ar is " + current_ar);

            if (buttonValue == current_answer){
                Debug.Log("Correct");
                triviaInputScriptable.givenAnswer = "Correct";

            }
            else{
                Debug.Log("Incorrect");
                triviaInputScriptable.givenAnswer = "Incorrect";
            }
            isPressed = false;
            questionInterface.SetActive(false);
        }

    }
}
