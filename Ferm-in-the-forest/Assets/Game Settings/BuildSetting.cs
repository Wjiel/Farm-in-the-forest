using UnityEngine;

[CreateAssetMenu(fileName = "BuildSetting", menuName = "Scriptable Objects/BuildSetting")]
public class BuildSetting : ScriptableObject
{
    public KeyCode RotateKey;
    public float RotateSpeed = 60;
    public float DistanceRay = 100;
    public LayerMask LayerBuild;
}
