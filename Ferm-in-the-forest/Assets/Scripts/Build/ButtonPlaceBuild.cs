using UnityEngine;

public class ButtonPlaceBuild : MonoBehaviour
{

    [SerializeField] private ToPlaceBuild Build;
    [SerializeField] private DisplayErrorBuild DisplayBuild;

    [SerializeField] private GameObject Tip;
    [SerializeField] private GameObject BuildingPrefab;

    public void PlaceBuild()
    {
        Tip.SetActive(true);

        Instantiate(BuildingPrefab, Vector3.zero, Quaternion.identity)
        .GetComponent<PlaceObject>().Init(Build, DisplayBuild);
    }
}
