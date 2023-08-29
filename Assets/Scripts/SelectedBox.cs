using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedBox : MonoBehaviour
{
    [SerializeField] private SelectableObject selectableObject;
    // Start is called before the first frame update
    void Start()
    {
       MouseInput.instance.OnObjectChanged += MouseInput_OnIntercableObjectChanged;
    }
    private void OnDestroy()
    {
        MouseInput.instance.OnObjectChanged -= MouseInput_OnIntercableObjectChanged;
    }

    private void MouseInput_OnIntercableObjectChanged(SelectableObject selectableObject)
    {
        if (selectableObject == this.selectableObject )
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    
    }


}
