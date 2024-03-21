using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class NewBehaviourScript : MonoBehaviour
{

    public GameObject wristUI;
    public bool activeWristUI = true;
    public XRBaseInteractor rightRayInteractor;
    private LineRenderer lineVisual;

    public PlayerStatsScriptableObject playerStatsScriptable;
    public BulletScriptableObject BulletScriptable;
    public JSONWriter saver;



    // Start is called before the first frame update
    void Start()
    {
        DisplayWristUI();



    }

    public void PauseButtonPress(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            DisplayWristUI();
        }
    }

    public void DisplayWristUI()
    {
 
        if (activeWristUI)
        {
            wristUI.SetActive(false);
            activeWristUI = false;
            Time.timeScale = 1;
            XRInteractorLineVisual lineVisual = rightRayInteractor.GetComponentInChildren<XRInteractorLineVisual>();
            lineVisual.enabled = false;


        }
        else if(!activeWristUI)
        {
            wristUI.SetActive(true);
            activeWristUI = true;
            Time.timeScale = 0;
            XRInteractorLineVisual lineVisual = rightRayInteractor.GetComponentInChildren<XRInteractorLineVisual>();
            lineVisual.enabled = true;

        }
    }



    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        playerStatsScriptable.currentHealth = 200;
        playerStatsScriptable.maxHealth = 200;
        BulletScriptable.bulletDamage = 10;
        BulletScriptable.bulletSpeed = 10;
        BulletScriptable.DHH = 0;
        BulletScriptable.DLH = 0;
        BulletScriptable.fireRate = 1;
        BulletScriptable.critChance = 1;

    }

    public void ExitGame()
    {
        //Application.Quit();
        saver.Save();
        SceneManager.LoadScene(0);
    }
}
