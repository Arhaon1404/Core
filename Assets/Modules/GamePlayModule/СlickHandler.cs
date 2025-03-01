using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class СlickHandler : MonoBehaviour
{
    [SerializeField] private Field _selectedFirstField;
    [SerializeField] private Field _selectedSecondField;
    private LevelStateMachine _levelStateMachine;
    public event Action<Field,Field> FieldsReceived;
    
    private void Awake()
    {
        _levelStateMachine = new LevelStateMachine();
        
        _levelStateMachine.EnterIn<StateWaitingFields>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                FindFields(hit);
            }
        }
    }

    private void FindFields(RaycastHit hit)
    {
        Debug.Log(hit.collider.gameObject.name);

        if (hit.collider.TryGetComponent(out Field field))
        {
            if (_selectedFirstField == null)
            {
                _selectedFirstField = field;
            }
            else
            {
                _selectedSecondField = field;
                FieldsReceived?.Invoke(_selectedFirstField,_selectedSecondField);
            }
        }
        else
        {
            _selectedFirstField = null;
            _selectedSecondField = null;
        }
    }
}
