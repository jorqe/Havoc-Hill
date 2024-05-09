using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;



public class H_Scale : MonoBehaviour {
    public JSONWriter saver;
    public PlayerStatsScriptableObject playerStatsScriptable;

    public string savePath;
    public string filePath;


    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(1.0f, 0.5f, 0.25f);
        getPath();
    }

    public string getPath()
    {
        savePath = Path.Combine(Application.persistentDataPath, "SaveSelection.txt");
        string textFromFile = File.ReadAllText(savePath);
        filePath = Path.Combine(Application.persistentDataPath, textFromFile);
        return filePath;
    }

    // Update is called once per frame
    void Update()
    {

            float ph = playerStatsScriptable.currentHealth;
            float mh = playerStatsScriptable.maxHealth;
            float x = ph/mh;
            if(x > 0f)
            {
                transform.localScale = new Vector3(x, 0.5f, 0.25f);
            }
            else
            {
                transform.localScale = new Vector3(0.0f, 0.5f, 0.25f);
            }



        if (playerStatsScriptable.currentHealth <= 0f)
        {

            File.Delete(getPath());
            SceneManager.LoadScene(0);
        }

    }
}