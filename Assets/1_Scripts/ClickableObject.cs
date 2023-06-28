using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
    }
    private void OnMouseDown()
    {
        // Perform your desired actions here
        
        Debug.Log("Clicked on the game object!");
        animator.SetTrigger("lift");
        
    }
}
