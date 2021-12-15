using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    private List<BuildingTypeSO> _buildings;
    private BuildingTypeSO _buildingType;
    private float _timer;
    private float _timerMax;

    private void Awake()
    {
        _buildingType = GetComponent<BuildingTypeHolder>().buildingType[0];
        _timerMax = _buildingType.resourceGeneratorData.timeMax;
        _buildings = GetComponent<BuildingTypeHolder>().buildingType;
    }

    private void Start()
    {
        var collider2DArray =
            Physics2D.OverlapCircleAll(transform.position,
                _buildingType.resourceGeneratorData.resourceDetectionRadius);

        var nearbyResourceAmount = 0;
        foreach (var collider2D in collider2DArray)
        {
            var resourceNode = collider2D.GetComponent<ResourceNode>();
            if (resourceNode != null)
                // it's a resource node!
                nearbyResourceAmount++;
        }

        nearbyResourceAmount = Mathf.Clamp(nearbyResourceAmount, 0,
            _buildingType.resourceGeneratorData.maxResourceAmount);

        if (nearbyResourceAmount == 0)
            // No resource nodes nearby
            // Disable resource generator
            enabled = false;
        else
            _timerMax = _buildingType.resourceGeneratorData.timeMax / 2f +
                        (1 - _buildingType.resourceGeneratorData.timeMax *
                            (nearbyResourceAmount / _buildingType.resourceGeneratorData.maxResourceAmount));

        Debug.Log($"nearbyResourceAmount: {nearbyResourceAmount}, timeMax: {_timerMax}");
    }

    private void Update()
    {
        foreach (var building in _buildings)
        {
            _buildingType = building;
            _timerMax = _buildingType.resourceGeneratorData.timeMax;

            _timer -= Time.deltaTime;

            if (_timer <= 0f)
            {
                _timer += _timerMax;
                ResourceManager.Instance.AddResource(_buildingType.resourceGeneratorData.resourceType, 1);
            }
        }
    }
}