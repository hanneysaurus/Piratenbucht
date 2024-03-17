using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.PlayerSettings;

public class StatusRing : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private RectTransform _area;

    private RectTransform _rectTransform = null;
    private CanvasGroup _canvasGroup = null;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.alpha = 1.0f;

        // place ring back on current state if outside the area
        if (!RectTransformUtility.RectangleContainsScreenPoint(_area, eventData.position, null))
        {
            ShipAreaHandler _shipAreaHandler = GetComponentInParent<ShipAreaHandler>();
            GameObject[] states = _shipAreaHandler.states;
            _rectTransform.localPosition = states[_shipAreaHandler.GetStatus()].GetComponent<RectTransform>().localPosition;
        }
    }

    private void Update()
    {
       
    }


}
