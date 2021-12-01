using System;
using Cinemachine;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;

    [SerializeField] float _moveSpeed = 15f;
    private float _orthographicSize;

    private void Start()
    {
        _orthographicSize = _cinemachineVirtualCamera.m_Lens.OrthographicSize;
    }

    private void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector2(xAxis, yAxis);
        transform.position += moveDirection * _moveSpeed * Time.deltaTime;

        _orthographicSize -= Input.mouseScrollDelta.y;
        _cinemachineVirtualCamera.m_Lens.OrthographicSize = _orthographicSize;
    }
}