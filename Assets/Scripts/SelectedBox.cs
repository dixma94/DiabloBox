using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedBox : MonoBehaviour
{
    [SerializeField] private SelectableObject npc;
    // Start is called before the first frame update
    void Start()
    {
       MouseInput.instance.OnIntercableObjectChanged += MouseInput_OnIntercableObjectChanged;
    }
    private void OnDestroy()
    {
        MouseInput.instance.OnIntercableObjectChanged -= MouseInput_OnIntercableObjectChanged;
    }

    private void MouseInput_OnIntercableObjectChanged(SelectableObject selectableObject)
    {
        if (selectableObject == npc )
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    
    }
}
