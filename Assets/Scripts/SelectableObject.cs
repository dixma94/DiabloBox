using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Zenject;

public class SelectableObject : MonoBehaviour
{
    public string info;
    public BoxCollider boxCollider;
    [SerializeField] private GameObject visualSelected;
    protected TipUI tipUI;

    [Inject]
    public void Construct(TipUI tipUI)
    {
        this.tipUI = tipUI;
    }

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
    public virtual void ShowInfo(){}
    
    public virtual void Interact(PlayerController player) { }

    public bool IsPlayerCanAttack()
    {
        return this is IDamageble;
    }
}

