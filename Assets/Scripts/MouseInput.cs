using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour, ImouseService
{
    public event Action<Vector3> OnEnvironmentClick;
    public event Action<IInteractable> OnObjectClick;
    public event Action<IDamageble> OnAttackableClick;
    public event Action<SelectableObject> OnObjectChanged;

    [SerializeField] private Camera _camera;

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
        if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition),out hit, 100))
        {
            if (hit.collider.TryGetComponent(out SelectableObject selectable))
            {
                OnObjectChanged?.Invoke(selectable);
            }
            else
            {
                OnObjectChanged?.Invoke(null);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.TryGetComponent(out IInteractable interactable))
                {
                    OnObjectClick?.Invoke(interactable);
                }
                else if(hit.collider.TryGetComponent(out IDamageble attackable))
                {
                    OnAttackableClick?.Invoke(attackable);
                }
                else
                {
                    OnEnvironmentClick?.Invoke(hit.point);
                }
            }

        }



       
    }

 
}
