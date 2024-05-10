using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class qButtonManagement : MonoBehaviour
{

    public GameObject trueButton;
    public GameObject falseButton;
    public GameObject button1;
    public GameObject button2;
    public TMP_Text button1Text;
    public TMP_Text button2Text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        if (PlayerPrefs.GetString("quiz") != "Spanish")
        {
            button1.SetActive(true);
            button2.SetActive(true);
            //button1Text.enabled = true;
            //button2Text.enabled = true;
            button1Text.gameObject.SetActive(true);
            button2Text.gameObject.SetActive(true);
        }
    }

    void OnDisable()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        button1Text.gameObject.SetActive(false);
        button2Text.gameObject.SetActive(false);
        //button1Text.enabled = false;
        //button2Text.enabled = false;
    }
}
