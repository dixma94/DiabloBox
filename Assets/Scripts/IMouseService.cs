using System;
using UnityEngine;

public interface ImouseService 
{
    event Action<Vector3> OnEnvironmentClick;
    event Action<IInteractable> OnObjectClick;
    public event Action<IDamageble> OnAttackableClick;
    event Action<SelectableObject> OnObjectChanged;
}
