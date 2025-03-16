using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 10;
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float zoomSpeed = 10;

    // Ограничения позиции камеры
    [SerializeField] private Vector2 xBounds = new Vector2(-100f, 100f);
    [SerializeField] private Vector2 yBounds = new Vector2(-15f, 25f);
    [SerializeField] private Vector2 zBounds = new Vector2(-100f, 100f);

    private float _speedMultiplier;
    private void Update()
    {
        SpeedUp();
        Move();
        Rotate();
        ZoomUp();
    }
    private void ZoomUp()
    {
        transform.position += transform.up * zoomSpeed * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel");

        transform.position = new Vector3(
              Mathf.Clamp(transform.position.x, xBounds.x, xBounds.y),
              Mathf.Clamp(transform.position.y, yBounds.x, yBounds.y),
              Mathf.Clamp(transform.position.z, zBounds.x, zBounds.y)
              );
    }
    private void SpeedUp()
    {
        _speedMultiplier = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
    }
    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * _speedMultiplier * Time.deltaTime;
        transform.Translate(movement, Space.Self);
    }
    private void Rotate()
    {
        float rotate = 0;

        if (Input.GetKey(KeyCode.Q))
            rotate = -1;
        else if (Input.GetKey(KeyCode.E))
            rotate = 1;

        float rotationAmount = rotate * rotateSpeed * _speedMultiplier * Time.deltaTime;
        transform.Rotate(Vector3.up * rotationAmount, Space.World);
    }

}
