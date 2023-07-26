using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour, ImouseService
{
    public event Action<Vector3> OnEnvironmentClick;
    public event Action<IInteractable, Vector3> OnInteractableClick;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                if(hit.collider.TryGetComponent(out IInteractable interactable))
                {
                    OnInteractableClick?.Invoke(interactable, hit.point);
                    return;
                }
                
            }
            OnEnvironmentClick?.Invoke(hit.point);
        }
    }
}
