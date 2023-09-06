using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectebleObjectsDictionary : MonoBehaviour
{
    [SerializeField] private MouseInput mouseInput;

    public Dictionary<int,SelectableObject> dictionary = new Dictionary<int,SelectableObject>();

    private SelectableObject currentSelect = null;

    private void Start()
    {
        CreateDictionary();
        mouseInput.OnSelection += MouseInput_OnSelection;
    }

    private void MouseInput_OnSelection(int objectID)
    {
        if (dictionary.TryGetValue(objectID, out SelectableObject newSelect))
        {

            if (currentSelect==null)
            {
                currentSelect = newSelect;
                newSelect.Select();
            }
            if (newSelect != currentSelect)
            {
                currentSelect.Diselect();
                newSelect.Select();
                currentSelect = newSelect;
            }
        }
        else
        {
            if (currentSelect != null)
            {
                currentSelect.Diselect();
                currentSelect = null;
            }
        }
    }

    private void CreateDictionary()
    {
        SelectableObject[] selectableObjects = FindObjectsOfType<SelectableObject>();
        foreach (SelectableObject item in selectableObjects)
        {
            dictionary.Add(item.boxCollider.GetInstanceID(), item);
        }
    }
}
