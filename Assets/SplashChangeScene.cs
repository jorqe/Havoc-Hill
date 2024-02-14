using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SplashChangeScene : MonoBehaviour
{
    int i = 7250;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        i--;

        if (i <= 0)
            SceneManager.LoadScene(2);

    }
}
