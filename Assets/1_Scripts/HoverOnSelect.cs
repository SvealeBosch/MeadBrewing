using UnityEngine;
using UnityEngine.EventSystems;

namespace _1_Scripts
{
    public class HoverOnSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Transform thisObject;
        [SerializeField] private float upAmount = 0.2f;
        [SerializeField] private float transitionDuration = 0.3f;
        [SerializeField] private LeanTweenType easingType = LeanTweenType.easeOutExpo;

        private Vector3 _originalPosition;

        private void Start()
        {
            _originalPosition = thisObject.position;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Vector3 targetPosition = _originalPosition + Vector3.up * upAmount;

            LeanTween.move(thisObject.gameObject, targetPosition, transitionDuration)
                .setEase(easingType);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            LeanTween.move(thisObject.gameObject, _originalPosition, transitionDuration)
                .setEase(easingType);
        }
    }
}