using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private List<Crystal> _crystals;

    public void Initialize(List<Crystal> crystals)
    {
        foreach (Crystal crystal in crystals)
        {
            if (crystal.Color != ColorType.Black)
            {
                _crystals.Add(crystal);
            }
        }
    }

    public void LightUpCrystals()
    {
        foreach (Crystal crystal in _crystals)
        {
            crystal.EndGameFireLightUp.LightUp();
        }
    }
}
