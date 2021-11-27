using UnityEngine;

[CreateAssetMenu(menuName = "GameObjects/BuildingType")]
public class BuildingTypeSO : ScriptableObject
{
    public string    name;
    public Transform prefab;
}