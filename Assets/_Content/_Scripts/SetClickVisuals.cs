using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetClickVisuals : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] PlaySounds playSounds;
    [SerializeField] AudioClip audioClip;
    public void OnPointerClick(PointerEventData eventData)
    {
        //if (EventSystem.current.IsPointerOverGameObject())
        //    return;
        this.gameObject.GetComponent<ObjectIndexHolder>().ShowSelectedItemUI();
        playSounds.PlayAudio(audioClip);
    }

}
