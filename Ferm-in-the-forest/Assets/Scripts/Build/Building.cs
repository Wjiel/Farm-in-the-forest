using UnityEngine;

public class ToPlaceBuild : MonoBehaviour
{
    [SerializeField] private GameObject Tip;
    public void DestroyBuild(GameObject building)
    {
        Destroy(building);

        Tip.SetActive(false);
    }
    public void TipDisable()
    {
        Tip.SetActive(false);
    }
}