/*
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleHoldDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private XRDirectInteractor directInteractor;
    

    void OnDisable()
    {
        // Update "Select Action Trigger"
        switch (dropdown.value)
        {
            case 0: // Toggle
                directInteractor.InputTriggerType = 2;
                break;
            case 1: // Hold 
                directInteractor.InputTriggerType = 3;
                break;
        }
    }
}
*/

using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using System.IO;


public class ToggleHoldDropdown : MonoBehaviour
{
    [SerializeField] private XRDirectInteractor directInteractor;

    // Define the InputTriggerType enumeration
    public enum InputTriggerType
    {
        Toggle,
        Sticky
    }

    void Start()
    {
        // Update "Select Action Trigger"
        switch (PlayerPrefs.GetInt("WeaponSetting"))
        {
    
            case 2: // Toggle
                directInteractor.selectActionTrigger = XRBaseControllerInteractor.InputTriggerType.Toggle;
                break;
            case 1: // Sticky 
                directInteractor.selectActionTrigger = XRBaseControllerInteractor.InputTriggerType.Sticky;
                break;
        }
         
    }
}
