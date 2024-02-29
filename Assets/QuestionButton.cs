using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestionButton : MonoBehaviour
{
    public GameObject press;
    public GameObject questionInterface;
    public TextBoxUpdate textBoxUpdate;
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
            Debug.Log("Type of buttonName is " + buttonName.GetType());
            Debug.Log("Type of textBoxUpdate.getAnswer is " + textBoxUpdate.getAnswer().GetType());
            Debug.Log("comparison of " + buttonName + " and " + textBoxUpdate.getAnswer() + " is " + (buttonName.Equals(textBoxUpdate.getAnswer(), StringComparison.Ordinal)));
            Debug.Log("buttonName is " + buttonName);
            Debug.Log("in questionbutton answer = " + textBoxUpdate.getAnswer());
            if (buttonName == textBoxUpdate.getAnswer()){
                Debug.Log("Correct");
            }
            else{
                Debug.Log("Incorrect");
            }
            isPressed = false;
            questionInterface.SetActive(false);
        }

    }
}
