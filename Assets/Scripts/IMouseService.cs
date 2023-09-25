using System;
using UnityEngine;

public interface ImouseService 
{
    public event Action<int> OnSelection;
    public event Action<int, Vector3> OnClick;
}
