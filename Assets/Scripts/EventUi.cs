using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class EventUi : MonoBehaviour, IPointerClickHandler
{
    public bool isOnPointerClick = false;
    void Start()
    {

    }
    void Update()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        isOnPointerClick = true;
    }
}
