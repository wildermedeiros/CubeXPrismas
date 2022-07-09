using UnityEngine;

[CreateAssetMenu(fileName = "EnergySO", menuName = "Energy/New Energy Data", order = 0)]
public class EnergySO : ScriptableObject 
{
    [SerializeField] float energyPoints = 100f;

    public float GetEnergyPoints()
    {
        return energyPoints;
    }    
}