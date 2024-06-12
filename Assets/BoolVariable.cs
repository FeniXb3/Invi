using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolVariable : ScriptableObject
{
  public bool value;

  public void Set(bool value)
  {
    this.value = value;
  }
}
