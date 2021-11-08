using UnityEngine;
using UnityEngine.InputSystem;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Update()
    {
        GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector2 mousePos      = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = _camera.ScreenToWorldPoint(mousePos);
        mouseWorldPos.z = 0f; // because camera.pos.z = -10.

        return mouseWorldPos;
    }
}