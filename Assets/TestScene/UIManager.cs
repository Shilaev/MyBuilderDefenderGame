using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // for Instantiane
    [SerializeField] private BuildingsData _buildings;
    private GameObject _selectableBuilding;

    // Mouse position
    [SerializeField] private Camera _camera;
    private Vector2 _mousePosition;
    private Vector2 _mousePositionWorld;

    // UI raycast fields
    [SerializeField] private GameObject _uiCanvas;
    private GraphicRaycaster _uiGraphicRaycaster;
    private PointerEventData _pointerEventData;
    private List<RaycastResult> _raycastResults;

    // Swipe detection
    private Vector2 _startMousePosition;
    private Vector2 _endMousePosition;

    private MyInput _input;

    private void OnEnable()
    {
        _input = new MyInput();
        _input.Enable();
    }

    private void Start()
    {

        // UI raycast setup
        _uiGraphicRaycaster = _uiCanvas.GetComponent<GraphicRaycaster>();
        _pointerEventData = new PointerEventData(EventSystem.current);
        _raycastResults = new List<RaycastResult>();

        _input.basicInputs.MousePosition.performed += ctx =>
        {
            _mousePosition = ctx.ReadValue<Vector2>();
            _mousePositionWorld = _camera.ScreenToWorldPoint(_mousePosition);
        };

        _input.basicInputs.SimpleClick.performed += ctx =>
        {
            if (Raycast2D().Count != 0)
            {
                foreach (RaycastResult raycastResult in Raycast2D())
                {
                    GameObject raycastedElement = raycastResult.gameObject;

                    if (raycastedElement.name == "RedButton")
                    {
                        _selectableBuilding = _buildings.Buildings[0];
                    }
                    
                    else if (raycastedElement.name == "YellowButton")
                    {
                        _selectableBuilding = _buildings.Buildings[1];
                    }
                    
                    else if (raycastedElement.name == "GreenButton")
                    {
                        _selectableBuilding = _buildings.Buildings[2];
                    }
                }
            }
            else if (_selectableBuilding)
            {
                Instantiate(_selectableBuilding, _mousePositionWorld, Quaternion.identity);
                _selectableBuilding = null;
            }

        };
    }

    private List<RaycastResult> Raycast2D()
    {
        _pointerEventData.position = _mousePosition;
        _raycastResults.Clear();
        
        _uiGraphicRaycaster.Raycast(_pointerEventData, _raycastResults);
        return _raycastResults;
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}
