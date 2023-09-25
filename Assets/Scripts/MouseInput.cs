using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInput : MonoBehaviour, ImouseService
{

    public event Action<int> OnSelection;
    public event Action<int, Vector3> OnClick;




    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                OnSelection?.Invoke(hit.collider.GetInstanceID());

                if (Input.GetMouseButtonDown(0))
                {
                    OnClick?.Invoke(hit.collider.GetInstanceID(), hit.point);
                }
            }
        }
    }
}
