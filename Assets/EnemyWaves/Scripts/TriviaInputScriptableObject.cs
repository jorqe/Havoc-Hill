using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TriviaInputScriptableObject", menuName = "ScriptableObjects/TriviaInput")]
public class TriviaInputScriptableObject : ScriptableObject{
    public string givenAnswer = "NoCurrentInput";
    public string current_hint = "";
    public int hint_flag = 0;
}