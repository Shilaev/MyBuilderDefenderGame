using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }
    private Camera _camera;
    private BuildingTypeListSO _buildingTypes;
    private BuildingTypeSO _activeBuildingType;

    public void SetActiveBuildingType(BuildingTypeSO buildingType)
    {
        _activeBuildingType = buildingType;
    }

    private void Awake()
    {
        Instance = this;
        _buildingTypes = Resources.Load<BuildingTypeListSO>("MainBuildings");
        _activeBuildingType = _buildingTypes.list[0];
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        // Choose building to spawn with keyboard
        if (Keyboard.current.digit1Key.wasReleasedThisFrame)
            _activeBuildingType = _buildingTypes.list[0];
        else if (Keyboard.current.digit2Key.wasReleasedThisFrame)
            _activeBuildingType = _buildingTypes.list[1];
        else if (Keyboard.current.digit3Key.wasReleasedThisFrame)
            _activeBuildingType = _buildingTypes.list[2];

        // spawn
        if (Mouse.current.leftButton.wasReleasedThisFrame && !EventSystem.current.IsPointerOverGameObject())
        {
            Transform instB = Instantiate(_activeBuildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 _mousePosition_World = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        _mousePosition_World.z = 0f;
        return _mousePosition_World;
    }
}