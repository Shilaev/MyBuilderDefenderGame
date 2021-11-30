using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildingManager : MonoBehaviour
{
    private Camera _camera;
    private BuildingTypeListSO _buildingTypeList;
    private BuildingTypeSO _buildingType;


    private void Awake()
    {
        _camera = Camera.main;
        _buildingTypeList = Resources.Load<BuildingTypeListSO>("MainBuildings");
        _buildingType = _buildingTypeList.list[0];
    }

    private void Update()
    {
        // Chose building to spawn
        if (Keyboard.current.digit1Key.wasReleasedThisFrame)
        {
            _buildingType = _buildingTypeList.list[0];
        }
        else if (Keyboard.current.digit2Key.wasReleasedThisFrame)
        {
            _buildingType = _buildingTypeList.list[1];
        }

        // spawn
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            var instB = Instantiate(_buildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 _mousePosition_World = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        _mousePosition_World.z = 0f;
        return _mousePosition_World;
    }
}