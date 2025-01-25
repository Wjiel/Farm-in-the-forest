using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float RotateSpeed = 10;
    [SerializeField] private float MoveSpeed = 10;
    [SerializeField] private float ZoomSpeed = 10;
    private float _mult;
    private void Update()
    {
        SpeedUp();
        Move();
        Rotate();
        ZoomUp();
    }
    private void ZoomUp()
    {
        transform.position += transform.up * ZoomSpeed * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel");

        transform.position = new Vector3(
             Mathf.Clamp(transform.position.x, -100, 100),
            Mathf.Clamp(transform.position.y, -15, 25),
             Mathf.Clamp(transform.position.z, -100, 100)
        );
    }
    private void SpeedUp()
    {
        _mult = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
    }
    private void Move()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(hor, 0, ver) * Time.deltaTime * _mult * MoveSpeed, Space.Self);
    }
    private void Rotate()
    {
        float rotate = 0;

        if (Input.GetKey(KeyCode.Q))
            rotate = -1;
        if (Input.GetKey(KeyCode.E))
            rotate = 1;

        transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime * rotate * _mult, Space.World);
    }

}
