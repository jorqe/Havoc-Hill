using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public GameObject button2;
    public UnityEvent onPress, onRelease;
    GameObject presser;
    bool isPressed;
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
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;
            
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.gameObject == presser){
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            onRelease.Invoke();
            isPressed = false;
            button2.SetActive(false);
        }
    }
}
