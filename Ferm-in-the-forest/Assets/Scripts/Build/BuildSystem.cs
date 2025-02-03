using UnityEngine;

public class BuildingMode : MonoBehaviour
{
    [SerializeField] private InteractBuild interactBuild;
    [SerializeField] private GameObject BuildInterface;
    [SerializeField] private GameObject BuildCanvas;

    private bool isBuilding;
    private void OnEnable()
    {
        DayNight.startNightAction += DisableBuild;
        DayNight.startDayAction += EnableBuild;
    }

    private void OnDisable()
    {
        DayNight.startNightAction -= DisableBuild;
        DayNight.startDayAction -= EnableBuild;
    }
    private void DisableBuild()
    {
        isBuilding = false;

        BuildInterface.SetActive(isBuilding);

        BuildCanvas.SetActive(false);

        interactBuild.enabled = true;
    }
    private void EnableBuild()
    {
        BuildCanvas.SetActive(true);
    }

    public void SwitchBuildingMode()
    {
        isBuilding = !isBuilding;

        BuildInterface.SetActive(isBuilding);

        interactBuild.enabled = !isBuilding;
    }


}
