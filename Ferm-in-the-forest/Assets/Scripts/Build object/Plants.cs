using UnityEngine;

public class Plants : MonoBehaviour, Interactable
{
    private PlantsView view;
    [SerializeField] private GameObject indecator;

    private void Start()
    {
        view = FindFirstObjectByType<PlantsView>();
    }
    public void ToInteract()
    {
        view.ActivePlants(indecator);
    }
}