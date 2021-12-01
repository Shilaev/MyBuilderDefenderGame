using System;
using Cinemachine;
using Unity.Mathematics;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
    [SerializeField] private float _moveSpeed = 15f;
    [SerializeField] private float _minZoom = 2;
    [SerializeField] private float _maxZoom = 10;
    [SerializeField] private float _zoomSpeed;
    private float _orthographicSize;
    private float _targetOrthographicSize;

    private void Start()
    {
        _orthographicSize = _cinemachineVirtualCamera.m_Lens.OrthographicSize;
        _targetOrthographicSize = _orthographicSize;
    }

    private void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector2(xAxis, yAxis);
        transform.position += moveDirection * _moveSpeed * Time.deltaTime;

        _targetOrthographicSize -= Input.mouseScrollDelta.y;
        _targetOrthographicSize = math.clamp(_targetOrthographicSize, _minZoom, _maxZoom);

        _zoomSpeed = 10f;
        _orthographicSize = math.lerp(_orthographicSize, _targetOrthographicSize, Time.deltaTime * _zoomSpeed);

        _cinemachineVirtualCamera.m_Lens.OrthographicSize = _orthographicSize;
    }
}