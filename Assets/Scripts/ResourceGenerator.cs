using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    private BuildingTypeSO _buildingType;
    private float _timer;
    private float _timerMax;
    private List<BuildingTypeSO> _buildings;

    private void Awake()
    {
        _buildingType = GetComponent<BuildingTypeHolder>().buildingType[0];
        _timerMax = _buildingType.ResourceGeneratorData.timeMax;
        _buildings = GetComponent<BuildingTypeHolder>().buildingType;
    }

    private void Update()
    {


        foreach (BuildingTypeSO building in _buildings)
        {
            _buildingType = building;
            _timerMax = _buildingType.ResourceGeneratorData.timeMax;

            _timer -= Time.deltaTime;

            if (_timer <= 0f)
            {
                _timer += _timerMax;
                ResourceManager.Instance.AddResource(_buildingType.ResourceGeneratorData.resourceType, 1);
            }
        }




    }
}