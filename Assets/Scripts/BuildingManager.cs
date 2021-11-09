using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private Camera     _camera;
    [SerializeField] private GameObject _goldenHarvester;
    [SerializeField] private GameObject _woodHarvester;
    [SerializeField] private GameObject _stoneHarvester;

    // Input
    private MainInputActions _input;

    // UI
    [SerializeField] private EventSystem         _uiEventSystem;
    [SerializeField] private Canvas              _uiCanvas;
    private                  GraphicRaycaster    _uiRaycaster;
    private                  PointerEventData    _uiData;
    private                  List<RaycastResult> _uiRaycastResults;

    #region [OnEnable|OnDisable]
    private void OnEnable()
    {
        // Input
        _input = new MainInputActions();
        _input.Enable();

        _input.BasicInput.MouseClick.performed += SpawnBuilding;

        // UI
        _uiRaycaster      = _uiCanvas.GetComponent<GraphicRaycaster>();
        _uiData           = new PointerEventData(_uiEventSystem);
        _uiRaycastResults = new List<RaycastResult>();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
    #endregion

    private void SpawnBuilding(InputAction.CallbackContext context) { }

    private GameObject GetBuildingsType()
    {
        _uiData.position = Mouse.current.position.ReadValue();
        _uiRaycastResults.Clear();
        _uiRaycaster.Raycast(_uiData, _uiRaycastResults);

        foreach (RaycastResult result in _uiRaycastResults)
        {
            GameObject uiElement = result.gameObject;

            if (uiElement.name == "Building_1")
                return _goldenHarvester;
            else if (uiElement.name == "Building_2")
                return _woodHarvester;
            else if (uiElement.name == "Building_3")
                return _stoneHarvester;
        }

        return null;
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