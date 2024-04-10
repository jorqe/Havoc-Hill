using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using System.IO;

public class WeaponSettings : MonoBehaviour

{
    
    [SerializeField] private TMP_Dropdown dropdown;
    // Start is called before the first frame update
    void OnDisable()
    {
        PlayerPrefs.SetString("WeaponSettings", dropdown.options[dropdown.value].text);
        
    }

}
