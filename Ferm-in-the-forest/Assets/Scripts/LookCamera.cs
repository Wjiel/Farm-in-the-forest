using UnityEngine;

public class LookCamera : MonoBehaviour
{
    [SerializeField] private GameObject PlaceHolder;
    private Camera _cameraMain;
    private void Start()
    {
        _cameraMain = Camera.main;
    }
    private void FixedUpdate()
    {
        PlaceHolder.transform.LookAt(_cameraMain.transform);
    }
}