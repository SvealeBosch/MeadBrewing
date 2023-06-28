using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScaleOnSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("References")]
    [SerializeField]
    private RectTransform rectTransform;
    
    [Header("Config")]
    [SerializeField]
    private Vector3 targetScale = new Vector3(1.2f, 1.2f, 1f); // The scale to tween to when the RectTransform is selected
    [SerializeField]
    private float transitionDuration = 0.3f; // The duration of the transition in seconds
    [SerializeField]
    private LeanTweenType easingType = LeanTweenType.easeOutExpo; // The easing type for the transition
    
    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = rectTransform.localScale;
    }

    private void ResetScale()
    {
        // Reset the scale of the RectTransform to its original scale
        LeanTween.scale(rectTransform, originalScale, transitionDuration)
            .setEase(easingType);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Scale up the RectTransform using LeanTween
        LeanTween.scale(rectTransform, targetScale, transitionDuration)
            .setEase(easingType);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ResetScale();
    }
}
