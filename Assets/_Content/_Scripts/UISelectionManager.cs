using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platinio;


 public class UISelectionManager : MonoBehaviour
{

    [SerializeField] private List<GearMenu> menus = new List<GearMenu>();
    public List<GameObject> colorPickers = new List<GameObject>();

    private int objectIndex;
    private bool isSomethingActive;

    
    public void CheckBeforeShow(int _objectInex)
    {
        objectIndex = _objectInex;
        isSomethingActive = false;

        if (menus[objectIndex].gameObject.transform.GetChild(0).gameObject.activeSelf == true && menus[objectIndex].isVisible)
        {
            return;
        }
        else
        {

           StartCoroutine(CheckBeforShowIEnum());
        }
    }
            
    IEnumerator CheckBeforShowIEnum()
    {
        foreach (GameObject _colorPicker in colorPickers)
        {
            _colorPicker.SetActive(false);
        }

        foreach (GearMenu item in menus)
        {
            if (item.gameObject.transform.GetChild(0).gameObject.activeSelf == true && int.Parse(item.gameObject.tag) != objectIndex)
            {
              
                item.HideCoroutine();
                if(item.isVisible) yield return new WaitForSeconds(2f);
              
                item.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        menus[objectIndex].gameObject.transform.GetChild(0).gameObject.SetActive(true);
        menus[objectIndex].ShowCoroutine();


    }

 }


