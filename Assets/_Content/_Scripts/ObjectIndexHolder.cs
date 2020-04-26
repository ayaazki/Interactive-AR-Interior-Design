using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Platinio;

public class ObjectIndexHolder : MonoBehaviour
{
    [SerializeField] private int objectIndex;
    [SerializeField] private GameObject _UISelectionMAnager;

    public static int choosenObjectIndex; //This is to read the choosen index for the check process in EventTriggerOverride


    public void ShowSelectedItemUI()
    {
        _UISelectionMAnager.GetComponent<UISelectionManager>().CheckBeforeShow(objectIndex);
        choosenObjectIndex = objectIndex;
    }
}
