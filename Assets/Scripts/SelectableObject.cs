using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    public string info;
    public BoxCollider boxCollider;

    [SerializeField] private GameObject visualSelected;
    [SerializeField] TipUI tipUI;

    private void Start()
    {
        visualSelected.SetActive(false);
        tipUI.Hide();
    }
    public void Select()
    {
        visualSelected.SetActive(true);
        tipUI.ShowInfo(this);
    }

    public void Diselect()
    {
        visualSelected.SetActive(false);
        tipUI.Hide();
    }
}
