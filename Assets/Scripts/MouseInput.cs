using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInput : MonoBehaviour
{

    public event Action<int> OnSelection;
    public event Action<int, Vector3> OnClick;

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
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit, 100))
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
