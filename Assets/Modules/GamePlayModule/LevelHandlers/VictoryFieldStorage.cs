using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryFieldStorage : MonoBehaviour
{
    [SerializeField] private StartField _startField;
    [SerializeField] private List<Field> _specialFields = new List<Field>();
    
    public StartField StartField => _startField;
    public List<Field> SpecialFields => _specialFields;
}
