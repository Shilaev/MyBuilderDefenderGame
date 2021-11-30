using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesUI : MonoBehaviour
{
    private ResourceTypeListSO _resourceTypes;
    private Dictionary<ResourceTypeSO, Transform> _resourceTypeTransformDictionary;
    private void Awake()
    {
        _resourceTypes = Resources.Load<ResourceTypeListSO>("MainResources");

        _resourceTypeTransformDictionary = new Dictionary<ResourceTypeSO, Transform>();

        Transform resourceTemplate = transform.Find("ResourceTemplate");
        resourceTemplate.gameObject.SetActive(false);

        int index = 0;
        foreach (var resource in _resourceTypes.list)
        {
            Transform resourceTransform = Instantiate(resourceTemplate, transform);
            resourceTransform.gameObject.SetActive(true);

            float offsetAmount = -130f;
            resourceTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0f);

            resourceTransform.Find("image").GetComponent<Image>().sprite = resource.sprite;

            _resourceTypeTransformDictionary[resource] = resourceTransform;
            index++;
        }
    }

    private void Start()
    {
        ResourceManager.Instance.OnResourceAmountChanged += ResourceManager_OnResourceAmountChanged;
        UpdateResourceAmount();
    }

    private void ResourceManager_OnResourceAmountChanged(object sender, EventArgs e)
    {
        UpdateResourceAmount();
    }

    private void UpdateResourceAmount()
    {
        foreach (ResourceTypeSO resourceType in _resourceTypes.list)
        {
            int resourceAmount = ResourceManager.Instance.GetResourceAmount(resourceType);

            Transform resourceTransform = _resourceTypeTransformDictionary[resourceType];
            resourceTransform.Find("lable").GetComponent<TextMeshProUGUI>().SetText(resourceAmount.ToString());
        }
    }
}
