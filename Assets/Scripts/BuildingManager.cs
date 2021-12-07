using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }
    private Camera _camera;
    private BuildingTypeListSO _buildingTypes;
    private BuildingTypeSO _activeBuildingType;
    private Transform _buildingGhost;

    public void SetActiveBuildingType(BuildingTypeSO buildingType)
    {
        _activeBuildingType = buildingType;
        _buildingGhost = GenerateBuildingGhost(buildingType);
    }

    private void Awake()
    {
        Instance = this;
        _buildingTypes = Resources.Load<BuildingTypeListSO>("MainBuildings");
        _activeBuildingType = null;
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        HandlePositionBuildingGhost();
        // spawn
        if (Mouse.current.leftButton.wasReleasedThisFrame && !EventSystem.current.IsPointerOverGameObject() && _activeBuildingType != null)
        {
            Transform newBuilding = Instantiate(_activeBuildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
            _activeBuildingType = null;
            _buildingGhost.AddComponent<DestroyMeAfterTime>();
            _buildingGhost = null;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 _mousePosition_World = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        _mousePosition_World.z = 0f;
        return _mousePosition_World;
    }

    private Transform GenerateBuildingGhost(BuildingTypeSO buildingType)
    {
        // position
        Transform newBuildingGhost = Instantiate(buildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);

        // color
        var color = newBuildingGhost.GetChild(0).GetComponent<SpriteRenderer>().color;
        var newColor = color;
        newColor.a = 0.5f;
        newBuildingGhost.GetChild(0).GetComponent<SpriteRenderer>().color = newColor;

        return newBuildingGhost;
    }

    private void HandlePositionBuildingGhost()
    {
        if (_buildingGhost != null)
        {
            _buildingGhost.transform.position = GetMouseWorldPosition();
        }
    }


}