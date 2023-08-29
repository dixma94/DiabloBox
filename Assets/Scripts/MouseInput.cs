using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour, ImouseService
{
    public event Action<Vector3> OnEnvironmentClick;
    public event Action<SelectableObject, Vector3> OnInteractableClick;
    public event Action<SelectableObject> OnIntercableObjectChanged;

    public static MouseInput instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Mouse Input in the scene.");
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            if (hit.collider.TryGetComponent(out SelectableObject interactable))
            {
                OnIntercableObjectChanged?.Invoke(interactable);
            }
            else
            {
                OnIntercableObjectChanged?.Invoke(null);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.TryGetComponent(out interactable))
                {
                    OnInteractableClick?.Invoke(interactable, hit.point);
                }
                else
                {
                    OnEnvironmentClick?.Invoke(hit.point);
                }
            }

        }



       
    }

 
}
