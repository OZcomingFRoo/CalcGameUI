using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Text constansts", fileName = "text")]
public class LabelText : ScriptableObject
{
    [SerializeField]
    private string title = "Test your calculation skills";

    [SerializeField]
    private string calculatePrefix = "Calculate the following";

    public string Title { get { return title; } }
    public string CalculatePrefix { get { return calculatePrefix; } }
}
