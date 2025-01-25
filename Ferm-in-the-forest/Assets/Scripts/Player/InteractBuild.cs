using UnityEngine;
/// <summary>
/// класс который взаимодействует со всеми зданиями
/// </summary>
public class InteractBuild : MonoBehaviour
{
    [SerializeField] private LayerMask layerBuild;
    private Camera _camera;
    private void Start()
    {
        _camera = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _interact();
    }
    private void _interact()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100, layerBuild))
        {
            if (hit.transform.TryGetComponent(out Interactable obj))
            {
                obj.ToInteract();
            }
        }
    }
}
