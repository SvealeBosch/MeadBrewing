using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBlocker : MonoBehaviour
{
    [SerializeField]
    private InteractionManager interactionManager;
    
    public void blockInput()
    {
        this.interactionManager.InputBlocked = true;
        Debug.Log("Interactions Blocked");
    }

    public void unblockInput()
    {
        this.interactionManager.InputBlocked = false;
        Debug.Log("Interactions unblocked");
    }
}
