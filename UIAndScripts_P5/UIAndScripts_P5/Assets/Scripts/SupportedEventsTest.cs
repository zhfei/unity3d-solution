using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
///
/// </summary>

public class SupportedEventsTest : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler
    ,IPointerExitHandler, IPointerUpHandler, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler, IDropHandler
    ,IScrollHandler, ISelectHandler, IDeselectHandler, IUpdateSelectedHandler, IMoveHandler, ISubmitHandler, ICancelHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnCancel(BaseEventData eventData)
    {
        Debug.Log("OnCancel");
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Debug.Log("OnDeselect");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        Debug.Log("OnInitializePotentialDrag");
    }

    public void OnMove(AxisEventData eventData)
    {
        Debug.Log("OnMove");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
    }

    public void OnScroll(PointerEventData eventData)
    {
        Debug.Log("OnScroll");
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("OnSelect");
    }

    public void OnSubmit(BaseEventData eventData)
    {
        Debug.Log("OnSubmit");
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        Debug.Log("OnUpdateSelected");
    }
}
