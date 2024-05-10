using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HintBoxScriptableObject", menuName = "ScriptableObjects/HintBox")]
public class HintBoxScriptableObject : ScriptableObject {
    public string current_hint = "";
    public int flag = 0;
}
