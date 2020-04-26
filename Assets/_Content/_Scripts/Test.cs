using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test : MonoBehaviour
{

    private void OnMouseUp()
    {
        this.gameObject.GetComponent<ObjectIndexHolder>().ShowSelectedItemUI();
    }

  
}
