using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    private ToPlaceBuild _build;
    private DisplayErrorBuild _displayBuild;

    [SerializeField] private BuildSetting setting;
    private Camera _cameraGame;
    private bool _canBuild = true;
    [SerializeField] private Renderer[] renderers;
    [SerializeField] private MonoBehaviour script;
    public void Init(ToPlaceBuild toPlace, DisplayErrorBuild displayError)
    {
        _build = toPlace;
        _displayBuild = displayError;
    }
    private void OnEnable()
    {
        DayNight.startNightAction += CanselBuild;
    }

    private void OnDisable()
    {
        DayNight.startNightAction -= CanselBuild;
    }

    private void Start()
    {
        _cameraGame = Camera.main;

        script.enabled = false;

        PositionObject();
    }
    private void Update()
    {
        PositionObject();

        if (Input.GetKey(setting.RotateKey))
            RotateObject();

        if (Input.GetMouseButtonDown(0))
            ToPlace();

        if (Input.GetMouseButtonDown(1))
            CanselBuild();
    }
    private void CanselBuild()
    {
        _build.DestroyBuild(gameObject);
    }
    private void ToPlace()
    {
        if (_canBuild)
        {
            _build.TipDisable();
            script.enabled = true;

            Destroy(this);
        }
        else
            _displayBuild.DisplayError();
    }
    private void PositionObject()
    {
        Ray ray = _cameraGame.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, setting.DistanceRay, setting.LayerBuild))
        {
            transform.position = new Vector3(hit.point.x, 0.12f, hit.point.z);
        }
    }
    private void RotateObject()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * setting.RotateSpeed);
    }
    private void OnCollisionStay(Collision other)
    {
        if (renderers[0].material.color != Color.red)
        {
            _canBuild = false;

            ChangeColor(Color.red);
        }
    }
    private void OnCollisionExit(Collision other)
    {
        _canBuild = true;

        ChangeColor(Color.white);
    }
    private void ChangeColor(Color _color)
    {
        foreach (var renderer in renderers)
            renderer.material.color = _color;
    }
}
