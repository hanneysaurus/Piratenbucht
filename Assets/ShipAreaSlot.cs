using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShipAreaSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] public int value = 0;
    [SerializeField] private int state;


    ShipAreaHandler _shipAreaHandler;
    private TextMeshProUGUI txt_value;

    private void Awake()
    {
        txt_value = GetComponentInChildren<TextMeshProUGUI>();
        txt_value.text = value.ToString();

        _shipAreaHandler = GetComponentInParent<ShipAreaHandler>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        //pointerDrag => opject that is being dragged
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
        _shipAreaHandler.SetStatus(state);
    }
}
