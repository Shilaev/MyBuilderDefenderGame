using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }

    public event EventHandler OnResourceAmountChanged;

    private Dictionary<ResourceTypeSO, int> _resourceAmountDictionary;

    private void Awake()
    {
        Instance = this;
        _resourceAmountDictionary = new Dictionary<ResourceTypeSO, int>();

        ResourceTypeListSO resources = Resources.Load<ResourceTypeListSO>("MainResources");

        foreach (ResourceTypeSO resource in resources.list)
            _resourceAmountDictionary[resource] = 0;
    }

    private void TestLogResourceAmountDictionary()
    {
        foreach (ResourceTypeSO key in _resourceAmountDictionary.Keys)
            print($"{key.resourceName}, {_resourceAmountDictionary[key]}");
    }

    public void AddResource(ResourceTypeSO resourceType, int amount)
    {
        _resourceAmountDictionary[resourceType] += amount;

        OnResourceAmountChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetResourceAmount(ResourceTypeSO resourceType)
    {
        return _resourceAmountDictionary[resourceType];
    }
}