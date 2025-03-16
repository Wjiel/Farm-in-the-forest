using UnityEngine;
using UnityEngine.EventSystems;
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
            TryInteract();
    }
    private void TryInteract()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out RaycastHit hit, 100, layerBuild))
        {
            if (hit.transform.TryGetComponent(out Interactable interactable))
            {
                interactable.ToInteract();
            }
        }
    }
}
