using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SplashChangeScene : MonoBehaviour
{
    int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 5;
    }

    // Update is called once per frame
    void Update()
    {
        i--;

        if (i <= 0)
            SceneManager.LoadScene(2);

    }
}
