using UnityEngine;
using UnityEngine.InputSystem;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Update()
    {
        var mousePos      = Mouse.current.position.ReadValue();
        var mouseWorldPos = _camera.ScreenToWorldPoint(mousePos);
    }
}
