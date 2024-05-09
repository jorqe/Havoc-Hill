using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class H_Scale : MonoBehaviour {
    public JSONWriter saver;
    public PlayerStatsScriptableObject playerStatsScriptable;
    public int l;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(1.0f, 0.5f, 0.25f);
        l = 0;
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
            SceneManager.LoadScene(0);
            l = 1;
            if(l == 1)
            {
                l = 0;
                //SingleSave();
                l = 0;
            }
            SceneManager.LoadScene(0);
        }

    }
    void SingleSave()
    {
        saver.killSave();
    }
}