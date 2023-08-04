using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ImouseService 
{
    event Action<Vector3> OnEnvironmentClick;
    event Action<IInteractable,Vector3> OnInteractableClick;
}