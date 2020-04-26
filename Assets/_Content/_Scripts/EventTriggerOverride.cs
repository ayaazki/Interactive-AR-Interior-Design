using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class EventTriggerOverride : EventTrigger
{

    public override void OnPointerDown(PointerEventData eventData)
    {
        string indexString = this.gameObject.transform.parent.parent.parent.parent.gameObject.tag;
        Debug.Log(indexString);
        int index = int.Parse(indexString);

        if (ObjectIndexHolder.choosenObjectIndex != index)
            return;
        base.OnPointerDown(eventData);
        Debug.Log("On Enter");
    }
}
