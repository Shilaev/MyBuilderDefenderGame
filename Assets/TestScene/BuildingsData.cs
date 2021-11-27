using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Buildings Data", menuName = "New Building data")]
public class BuildingsData : ScriptableObject
{

    [SerializeField] private List<GameObject> _buildings;
    public List<GameObject> Buildings
    {
        get => _buildings;
        private set => _buildings = value;
    }
}
