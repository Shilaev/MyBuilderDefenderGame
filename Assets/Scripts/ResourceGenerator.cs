using System;
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
        _timerMax = _buildingType.resourceGeneratorData.timeMax;
        _buildings = GetComponent<BuildingTypeHolder>().buildingType;
    }

    private void Update()
    {

        foreach (BuildingTypeSO building in _buildings)
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

    private void Start()
    {
        Collider2D[] collider2DArray =
                Physics2D.OverlapCircleAll(transform.position,
                                           _buildingType.resourceGeneratorData.resourceDetectionRadius);

        int nearbyResourceAmount = 0;
        foreach (Collider2D collider2D in collider2DArray)
        {
            ResourceNode resourceNode = collider2D.GetComponent<ResourceNode>();
            if (resourceNode != null)
            {
                // it's a resource node!
                nearbyResourceAmount++;
            }
        }

        nearbyResourceAmount = Mathf.Clamp(nearbyResourceAmount, 0,
                                           _buildingType.resourceGeneratorData.maxResourceAmount);

        if (nearbyResourceAmount == 0)
        {
            // No resource nodes nearby
            // Disable resource generator
            enabled = false;
        }

        Debug.Log($"nearbyResourceAmount: {nearbyResourceAmount}");
    }
}