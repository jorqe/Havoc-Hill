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
    public JSONReader loader;

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
        saver.deathSave();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
    public void SaveGame()
    {
        if (saver != null)
        {
            saver.killSave();
        }
        else
        {
            Application.Quit();
        }
    }
}
