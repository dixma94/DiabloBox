using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public event Action<Vector3> OnEnvironmentClick;
    public event Action<SelectableObject, Vector3> OnInteractableClick;
    public event EventHandler<OnIntercableObjectChangedEventArgs> OnIntercableObjectChanged;
    public class OnIntercableObjectChangedEventArgs : EventArgs
    {
        public SelectableObject interactableObject;
    }


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            if (hit.collider.TryGetComponent(out SelectableObject interactable))
            {
                OnIntercableObjectChanged?.Invoke(this, new OnIntercableObjectChangedEventArgs()
                {
                    interactableObject = interactable
                }) ;
            }
            else
            {
                OnIntercableObjectChanged?.Invoke(this, new OnIntercableObjectChangedEventArgs()
                {
                    interactableObject = null
                }) ;
            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                if (hit.collider.TryGetComponent(out SelectableObject interactable))
                {
                    OnInteractableClick?.Invoke(interactable, hit.point);
                    return;
                }
                OnEnvironmentClick?.Invoke(hit.point);
            }
        }

       
    }
}
