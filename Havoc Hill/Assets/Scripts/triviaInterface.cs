using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triviaInterface : MonoBehaviour
{
    public GameObject questionInterface;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other){
        Debug.Log("inside the trigger enter function");
        questionInterface.SetActive(false);
    }
}
