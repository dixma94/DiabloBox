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
        mouseInput.OnIntercableObjectChanged += MouseInput_OnIntercableObjectChanged;
    }

    private void MouseInput_OnIntercableObjectChanged(object sender, MouseInput.OnIntercableObjectChangedEventArgs e)
    {
        if (e.interactableObject != null)
        {
            textMeshPro.text = e.interactableObject.info;
            gameObject.SetActive(true);

        }
        else
        {
            gameObject.SetActive(false);
        }

    }
}
