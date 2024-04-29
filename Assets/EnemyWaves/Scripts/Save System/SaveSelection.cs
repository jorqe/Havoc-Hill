using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.IO;

public class SaveSelection : MonoBehaviour
{
    public string buttonValue;
    public GameObject press;
    bool isPressed;
    GameObject presser;
    string buttonName;
    public string saveName;
    public string filePath;
    // Start is called before the first frame update
    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "SaveSelection.txt");
        isPressed = false;
        buttonName = gameObject.name;
    }

    // Update is called once per frame


    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            press.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            //onPress.Invoke();
            isPressed = true;

        }
    }

    public string GetSaveName()
    {
        return saveName;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            press.transform.localPosition = new Vector3(0, 0.015f, 0);

            if(buttonName == "Save1")
            {
                saveName = "JsonText1.txt";
                File.WriteAllText(filePath, "JsonText1.txt");
            }
            else if(buttonName == "Save2")
            {
                saveName = "JsonText2.txt";
                File.WriteAllText(filePath, "JsonText2.txt");
            }
            else if(buttonName == "demo")
            {
                saveName = "DemoText.txt";
                File.WriteAllText(filePath, "DemoText.txt");
            }
            else
            {
                saveName = "JsonText.txt";
                File.WriteAllText(filePath, "JsonText.txt");
            }
        }

    }
}
