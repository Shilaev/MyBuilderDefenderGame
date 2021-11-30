using UnityEngine;
using UnityEngine.InputSystem;

public class BuildingManager : MonoBehaviour
{
    private Camera _camera;
    private BuildingTypeListSO _buildingTypeList;
    private BuildingTypeSO _buildingType;

    private void Awake()
    {
        _buildingTypeList = Resources.Load<BuildingTypeListSO>("MainBuildings");
        _buildingType = _buildingTypeList.list[0];
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        // Choose building to spawn
        if (Keyboard.current.digit1Key.wasReleasedThisFrame)
            _buildingType = _buildingTypeList.list[0];
        else if (Keyboard.current.digit2Key.wasReleasedThisFrame)
            _buildingType = _buildingTypeList.list[1];
        else if (Keyboard.current.digit3Key.wasReleasedThisFrame)
            _buildingType = _buildingTypeList.list[2];
        else if (Keyboard.current.digit4Key.wasReleasedThisFrame)
            _buildingType = _buildingTypeList.list[3];

        // spawn
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            Transform instB = Instantiate(_buildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 _mousePosition_World = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        _mousePosition_World.z = 0f;
        return _mousePosition_World;
    }
}