using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeSelectUIGenerator : MonoBehaviour
{
    [SerializeField] private Transform _btnTemplate;
    private BuildingTypeListSO _buildingTypes;
    private Dictionary<BuildingTypeSO, Transform> _btnTransform;

    private void Awake()
    {
        _buildingTypes = Resources.Load<BuildingTypeListSO>("MainBuildings");

        int index = 0;
        foreach (BuildingTypeSO building in _buildingTypes.list)
        {
            Transform button = Instantiate(_btnTemplate, transform);
            button.gameObject.SetActive(true);

            // button spawn position
            float offset = 150f;
            button.GetComponent<RectTransform>().anchoredPosition = new Vector2(offset * index, 0f);
            index++;

            // button setup
            button.GetChild(1).GetComponent<Image>().sprite = building.sprite;
            button.GetChild(2).GetComponent<TextMeshProUGUI>().text = building.buildingName;

            // On click
            button.GetComponent<Button>().onClick.AddListener(() =>
            {
                BuildingManager.Instance.SetActiveBuildingType(building);
            });
        }
    }
}