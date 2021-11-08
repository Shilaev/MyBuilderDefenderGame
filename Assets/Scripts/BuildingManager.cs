using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private Camera     _camera;
    [SerializeField] private GameObject _objectToSpawn;

    // input action
    private MainInputActions _input;

    #region [OnEnable|OnDisable]
    private void OnEnable()
    {
        _input = new MainInputActions();
        _input.Enable();

        _input.BasicInput.MouseClick.performed += SpawnBuilding;
    }

    private void OnDisable()
    {
        _input.Disable();
    }
    #endregion

    private void SpawnBuilding(InputAction.CallbackContext context)
    {
        SpawnObjectHere(_objectToSpawn, GetMouseWorldPos());
    }

    /// <summary>
    ///     Return current mouse position in scene
    /// </summary>
    /// <returns></returns>
    private Vector3 GetMouseWorldPos()
    {
        Vector2 mousePos      = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = _camera.ScreenToWorldPoint(mousePos);
        mouseWorldPos.z = 0f; // because camera.pos.z = -10.
        return mouseWorldPos;
    }

    private void SpawnObjectHere(GameObject objectToSpawn, Vector3 spawnPos)
    {
        Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
    }
}