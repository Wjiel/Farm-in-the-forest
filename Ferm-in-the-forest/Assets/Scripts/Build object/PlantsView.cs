using UnityEngine;

public class PlantsView : MonoBehaviour
{
    [SerializeField] private GameObject CanvasInt;
    private GameObject _selectedIndecator;
    private bool _isVisible;
    public void ExitPlantCanvas()
    {
        _isVisible = false;

        CanvasInt.SetActive(_isVisible);
        _selectedIndecator.SetActive(_isVisible);
    }
    public void ActivePlants(GameObject ind)
    {
        if (_selectedIndecator != null)
            _selectedIndecator.SetActive(false);

        _selectedIndecator = ind;

        _isVisible = true;

        CanvasInt.SetActive(_isVisible);
        _selectedIndecator.SetActive(_isVisible);
    }
}
