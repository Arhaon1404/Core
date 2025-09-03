using System;
using System.Collections.Generic;
using UnityEngine;

public class Backlighter : MonoBehaviour
{
    [SerializeField] private MapGenerator _mapGenerator;
    [SerializeField] private WaitingIcon _waitingIcon;
    
    [SerializeField] private List<Crystal> _crystals;
    
    private FieldSelector _fieldSelector;
    
    private void OnEnable()
    {
        _waitingIcon.IsCoreMoving += ActMoveCore;
    }

    private void OnDisable()
    {
        _waitingIcon.IsCoreMoving -= ActMoveCore;
        _fieldSelector.StateNoneAchieved -= RebootBacklight;
    }

    public void Initialize(FieldSelector fieldSelector)
    {
        if (fieldSelector == null)
            throw new ArgumentNullException(nameof(fieldSelector));
        
        _fieldSelector = fieldSelector;

        _fieldSelector.StateNoneAchieved += RebootBacklight;
        
        _crystals = _mapGenerator.ProvideListCrystals();

        foreach (Crystal crystal in _crystals)
        {
            crystal.OutlineSwicher.OnActived += PressCrystal;
            crystal.OutlineSwicher.OnDeactivated += TurnOnBacklight;
        }

        TurnOnBacklight();
    }
    
    public void PressCrystal()
    {
        foreach (Crystal crystal in _crystals)
        {
            crystal.TurnOffBacklight();
            
            Transform crystalField = crystal.transform.parent;
            
            if (crystalField.TryGetComponent(out Field field))
            {
                field.DeactivateBacklight();
            }
        }
    }
    
    public void TurnOnBacklight()
    {
        foreach (Crystal crystal in _crystals)
        {
            if(crystal.IsActiveCrystal == false) continue;
            
            Transform crystalField = crystal.transform.parent;

            if (crystalField.TryGetComponent(out Field field))
            {
                bool isEnableToMove = СheckPossibilityMove(field);

                if (isEnableToMove)
                {
                    crystal.TurnOnBacklight();
                    
                    field.ActivateBacklight();
                }
            }
        }
    }
    
    private void ActMoveCore(bool isMoving)
    {
        if (isMoving)
        {
            PressCrystal();
        }
        else
        {
            TurnOnBacklight();
        }
    }

    private bool СheckPossibilityMove(Field field)
    {
        foreach (Connection connection in field.ActiveConnections)
        {
            if(connection.enabled == false)continue;
            if(connection.ConnectionLine.gameObject.activeSelf == false)continue;
            
            if (connection.ConnectionLine.AisleColors.Count == 0)
            {
                if (connection.ConnectionAnotherField.MotherField.CrystalOnField == null)
                {
                    return true;
                }
            }
            else
            {
                Crystal currentCrystal = field.CrystalOnField;

                foreach (ColorType color in connection.ConnectionLine.AisleColors)
                {
                    if (currentCrystal.Color == color)
                    {
                        if (connection.ConnectionAnotherField.MotherField.CrystalOnField == null)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        
        return false;
    }

    private void RebootBacklight()
    {
        PressCrystal();
        TurnOnBacklight();
    }
}
