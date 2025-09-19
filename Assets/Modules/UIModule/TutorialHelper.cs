using System;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHelper : MonoBehaviour
{
    [SerializeField] private ArrowPointer _arrowPointerPrefab;
    
    private FieldSelector _fieldSelector;

    private float _spawnUpShift; 
    
    private Field _fieldWithCrystal;
    
    private ArrowPointer _arrowPointerWithCrystal;
    private List<ArrowPointer> _arrowPointersWithField;
    
    private int _firstLevelTutorial = 1;
    private int _secondLevelTutorial = 2;

    public int FirstLevelTutorial => _firstLevelTutorial;
    public int SecondLevelTutorial => _secondLevelTutorial;

    public void Initialize(List<Field> fields,FieldSelector fieldSelector)
    {
        foreach (Field field in fields)
        {
            if (field.CrystalOnField != null)
            {
                _fieldWithCrystal = field;
                break;
            }
        }

        _spawnUpShift = 2.5f;
        
        _fieldSelector = fieldSelector;
        
        _fieldSelector.StateUpdated += ChangePointerState;
        
        ActivatePointerWithCrystal();
    }

    private void ActivatePointerWithCrystal()
    {
        ArrowPointer arrowPointer = Instantiate(_arrowPointerPrefab,_fieldWithCrystal.transform.position,_arrowPointerPrefab.transform.rotation);
        
        _arrowPointerWithCrystal = arrowPointer;
        
        _arrowPointerWithCrystal.transform.parent = _fieldWithCrystal.transform;
        
        Vector3 newPosition = new Vector3(_arrowPointerWithCrystal.transform.position.x,(_arrowPointerWithCrystal.transform.position.y + _spawnUpShift),_arrowPointerWithCrystal.transform.position.z);
        
        _arrowPointerWithCrystal.transform.position = newPosition;
        
        _arrowPointerWithCrystal.PlayAnimation();
    }

    private void ChangePointerState(State state, Field startField, Field endField)
    {
        if (state == State.HasStart)
        {
            _arrowPointerWithCrystal.PauseAnimation();
            
            if (_arrowPointersWithField == null)
            {
                _arrowPointersWithField = new List<ArrowPointer>();
                
                foreach (Connection connection in startField.ActiveConnections)
                {
                    if (connection.ConnectionAnotherField.MotherField.CrystalOnField == null)
                    {
                        Field anotherField = connection.ConnectionAnotherField.MotherField;
                        
                        ArrowPointer arrowPointer = Instantiate(_arrowPointerPrefab,anotherField.transform.position,_arrowPointerPrefab.transform.rotation);
                        
                        _arrowPointersWithField.Add(arrowPointer);

                        arrowPointer.transform.parent = anotherField.transform;
                        
                        Vector3 newPosition = new Vector3(arrowPointer.transform.position.x,(arrowPointer.transform.position.y + _spawnUpShift),arrowPointer.transform.position.z);
        
                        arrowPointer.transform.position = newPosition;
                        
                        arrowPointer.PlayAnimation();
                    }
                }
                
                Debug.Log(_arrowPointersWithField);
            }
            else
            {
                foreach (ArrowPointer arrowPointer in _arrowPointersWithField)
                {
                    arrowPointer.PlayAnimation();
                }
            }
        }
        else if (state == State.HasEnd)
        {
            foreach (ArrowPointer arrowPointer in _arrowPointersWithField)
            {
                arrowPointer.PauseAnimation();
            }
        }
        else if (state == State.None)
        {
            foreach (ArrowPointer arrowPointer in _arrowPointersWithField)
            {
                arrowPointer.PauseAnimation();
            }
            
            _arrowPointerWithCrystal.PlayAnimation();
        }
    }
}
