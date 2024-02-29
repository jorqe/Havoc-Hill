using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionButton : MonoBehaviour
{
    public GameObject press;
    public GameObject questionInterface;
    public TextBoxUpdate textBoxUpdate;
    public string current_answer;
    bool isPressed;
    GameObject presser;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
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
            Debug.Log("gameObject.name is " + gameObject.name);
            Debug.Log("in questionbutton answer = " + textBoxUpdate.getAnswer());
            if (gameObject.name == textBoxUpdate.getAnswer()){
                Debug.Log("Correct");
                current_answer = "true";

            }
            else{
                Debug.Log("Incorrect");
                current_answer = "false";
            }
            textBoxUpdate.setInput(current_answer);
            isPressed = false;
            questionInterface.SetActive(false);
        }

    }
}
