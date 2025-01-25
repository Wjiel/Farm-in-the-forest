using UnityEngine;

public class BuildingMode : MonoBehaviour
{
    [SerializeField] private InteractBuild interactBuild;
    [SerializeField] private GameObject BuildInterface;

    private bool isBuilding;
    public void SwitchBuildingMode()
    {
        isBuilding = !isBuilding;

        BuildInterface.SetActive(isBuilding);

        interactBuild.enabled = !isBuilding;
    }
}
