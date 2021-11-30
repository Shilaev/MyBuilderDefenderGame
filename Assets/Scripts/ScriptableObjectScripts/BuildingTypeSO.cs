using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = default, menuName = "BuildingType")]
public class BuildingTypeSO : ScriptableObject
{
    public string buildingName;
    public Transform prefab;
    public ResourceGeneratorData ResourceGeneratorData;
}