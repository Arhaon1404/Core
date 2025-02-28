using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class СlickHandler : MonoBehaviour
{
    [SerializeField] private Crystal _selectedCrystal;
    [SerializeField] private Field _selectedField;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                SwitchSearchStages(hit);
            }
        }
    }

    private void SwitchSearchStages(RaycastHit hit)
    {
        Debug.Log(hit.collider.gameObject.name);
        if (_selectedCrystal == null)
        {
            SearchCrystal(hit);
        }
        else if (_selectedCrystal != null)
        { 
            SearchField(hit);
        }
    }

    private void SearchCrystal(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent(out Crystal crystal))
            _selectedCrystal = crystal;
        else
            _selectedCrystal = null;    
    }

    private void SearchField(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent(out Field field))
            _selectedField = field;
        else
            _selectedCrystal = null;
    }
}
