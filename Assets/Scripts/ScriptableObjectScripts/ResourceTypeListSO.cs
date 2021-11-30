using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = default, menuName = "Resource type list")]
public class ResourceTypeListSO : ScriptableObject
{
    public List<ResourceTypeSO> list;
}