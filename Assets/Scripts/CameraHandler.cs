using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    private void Start() { }

    [SerializeField] float _moveSpeed = 15f;

    private void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector2(xAxis, yAxis);
        transform.position += moveDirection * _moveSpeed * Time.deltaTime;
    }
}