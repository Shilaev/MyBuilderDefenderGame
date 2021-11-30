using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = default, menuName = "Building type list")]
public class BuildingTypeListSO : ScriptableObject
{
    public List<BuildingTypeSO> list;
}