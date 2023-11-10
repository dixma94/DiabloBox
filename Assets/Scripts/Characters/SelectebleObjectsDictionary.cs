using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static UnityEditor.Progress;

public class SelectebleObjectsDictionary 
{


    public Dictionary<int,SelectableObject> dictionary = new Dictionary<int,SelectableObject>();
    private SelectableObject currentSelect = null;

    public SelectebleObjectsDictionary(ImouseService input)
    {
        input.OnSelection += MouseInput_OnSelection;
        CreateDictionary();
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
        SelectableObject[] selectableObjects = Object.FindObjectsOfType<SelectableObject>();
        foreach (SelectableObject item in selectableObjects)
        {
            dictionary.Add(item.boxCollider.GetInstanceID(), item);
        }
    }
    public void AddToDictionary(SelectableObject selectableObject)
    {
        dictionary.Add(selectableObject.boxCollider.GetInstanceID(), selectableObject);
    }
}
