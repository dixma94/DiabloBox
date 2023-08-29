using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TipUI : MonoBehaviour
{
    [SerializeField] private MouseInput mouseInput;
    [SerializeField] private TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        mouseInput.OnObjectChanged += MouseInput_OnIntercableObjectChanged;
    }

    private void MouseInput_OnIntercableObjectChanged(SelectableObject selectableObject)
    {
        if (selectableObject != null)
        {
            textMeshPro.text = selectableObject.info;
            gameObject.SetActive(true);

        }
        else
        {
            gameObject.SetActive(false);
        }

    }
}
