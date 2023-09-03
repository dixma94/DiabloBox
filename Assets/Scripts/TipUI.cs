using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TipUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI textMeshPro;


    public void ShowInfo(SelectableObject selectableObject)
    {
        gameObject.SetActive(true);
        textMeshPro.text = selectableObject.info;
    }
    public void Hide()
    {
        gameObject.SetActive(false);

    }
}
