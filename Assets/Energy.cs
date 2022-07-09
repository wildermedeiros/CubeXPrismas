using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] float startingEnergyPoints = 100f;

    [SerializeField] float energyPoints;

    private void Awake() 
    {
        energyPoints = startingEnergyPoints;
    }
    
    public void ConsumeEnergy(float pointsToConsume)
    {
        energyPoints -= Mathf.Abs(pointsToConsume);

        //energyPoints = Mathf.Max(energyPoints - pointsToConsume, 0);
        // if (energyPoints == 0)
        // {
            
        // }
    }

    public float GetEnergyPoints() { return energyPoints; }

}
