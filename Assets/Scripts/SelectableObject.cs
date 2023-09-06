using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    public string info;
    public BoxCollider boxCollider;
    public TipUI tipUI;

    [SerializeField] private GameObject visualSelected;

    private void Start()
    {
        visualSelected.SetActive(false);
        tipUI.Hide();
    }
    public void Select()
    {
        visualSelected.SetActive(true);
        ShowInfo();
    }

    public void Diselect()
    {
        tipUI.Hide();
        visualSelected.SetActive(false);
        
    }
    public virtual void ShowInfo()
    {

    }

}

