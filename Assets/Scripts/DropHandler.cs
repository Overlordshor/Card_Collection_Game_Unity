using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Action OnFinishedPlace;
    private DragHandler _card;

    private void GetComponentDragHandler(PointerEventData eventData)
    {
        _card = eventData.pointerDrag.GetComponent<DragHandler>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GetComponentDragHandler(eventData);
        if (transform.childCount > Configuration.MaxCountCardsOnField)
        {
            OnFinishedPlace();
            return;
        }

        if (_card)
        {
            _card.DefaultParent = transform;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            GetComponentDragHandler(eventData);
            if (_card)
            {
                _card.DefaultTempCardParent = transform;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            GetComponentDragHandler(eventData);
            if (_card && _card.DefaultTempCardParent == transform)
            {
                _card.DefaultTempCardParent = _card.DefaultParent;
            }
        }
    }
}