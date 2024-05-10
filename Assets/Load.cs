using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    public JSONWriter saver;
    // Start is called before the first frame update
    void Start()
    {
        saver.deathSave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
