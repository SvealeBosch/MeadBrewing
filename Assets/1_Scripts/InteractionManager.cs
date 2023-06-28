using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private RectTransform uiCanvasRectTransform; 
    [SerializeField] private TextMeshProUGUI instructionLabel;
    [SerializeField] private TextMeshProUGUI helpLabel;
    [SerializeField] private TextMeshProUGUI errorLabel;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject hintContainer;
    [SerializeField] private RectTransform errorContainer;
    [SerializeField] private TextMeshProUGUI hintsCountLabel;
    [SerializeField] private TextMeshProUGUI mistakesCountLabel;
    [SerializeField] private TextMeshProUGUI statsHintsCountLabel;
    [SerializeField] private TextMeshProUGUI statsMistakesCountLabel;

    [SerializeField] private List<Interaction> interactions;
    private Interaction currentInteraction;
    private int interactionIndex;
    private Vector2 mouseOnCanvasPos;
    
    private int mistakesCount;
    private int hintCount;

    private Camera cam;

    private void Awake() => cam = Camera.main;

    private void Start()
    {
        currentInteraction = interactions[interactionIndex];
        instructionLabel.SetText(currentInteraction.Instruction);
        helpLabel.SetText(currentInteraction.HelpMsg);
        errorLabel.SetText(currentInteraction.ErrorMsg);
    }

    void Update()
    {
        DebugDrawRay();

        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in screen coordinates
            Vector2 screenPos = Input.mousePosition;
            // Convert the screen position to the local position inside the canvas
            RectTransformUtility.ScreenPointToLocalPointInRectangle(uiCanvasRectTransform, screenPos, null, out this.mouseOnCanvasPos);

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 20.0f, layerMask))
            {
                CheckInteractionOrder(hit.transform.gameObject);
                String objectName = hit.transform.gameObject.name.ToString();
                Debug.Log(objectName);
            }
            
        }
    }

    private void CheckInteractionOrder(GameObject selectedGameObject)
    {
        if (selectedGameObject.Equals(currentInteraction.GameObject))
        {
            StopHelpAndErrorDisplay();
            currentInteraction.OnExecution?.Invoke();
            
            interactionIndex++;
            if(interactionIndex >= interactions.Count)
                return;
            
            currentInteraction = interactions[interactionIndex];
            instructionLabel.SetText(currentInteraction.Instruction);
            helpLabel.SetText(currentInteraction.HelpMsg);
            errorLabel.SetText(currentInteraction.ErrorMsg);
        }
        else
        {
            countmistake();
            StartCoroutine(DisplayForDuration(errorLabel, currentInteraction.ErrorMsg, 3.0f));
        }
    }

    private void DebugDrawRay()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 20.0f, layerMask))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.green);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 20.0f, Color.red);
        }
    }
    
    /// <summary>
    /// This coroutine displays a text (msg) for a fixed number of seconds (duration)
    /// on a Text UI Element (label).
    /// </summary>
    private IEnumerator DisplayForDuration(TextMeshProUGUI label, string msg, float duration)
    {
        label.text = msg;
        errorContainer.anchoredPosition = this.mouseOnCanvasPos;
        errorContainer.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        label.text = "";
        errorContainer.gameObject.SetActive(false);
    }

    private void StopHelpAndErrorDisplay()
    {
        StopAllCoroutines();
        hintContainer.gameObject.SetActive(false);
        errorContainer.gameObject.SetActive(false);
    }

    public void countHint()
    {
        this.hintCount += 1;
        this.hintsCountLabel.SetText(this.hintCount.ToString());
    }

    public void countmistake()
    {
        this.mistakesCount += 1;
        this.mistakesCountLabel.SetText(this.mistakesCount.ToString());
    }

    public void getStats()
    {
        this.statsHintsCountLabel.SetText(this.hintCount.ToString());
        this.statsMistakesCountLabel.SetText(this.mistakesCount.ToString());
    }
}
