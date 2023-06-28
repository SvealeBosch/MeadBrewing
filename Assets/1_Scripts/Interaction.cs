using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct Interaction
{
    public GameObject GameObject;
    public string Instruction;
    public string HelpMsg;
    public string ErrorMsg;
    public UnityEvent OnExecution;
}