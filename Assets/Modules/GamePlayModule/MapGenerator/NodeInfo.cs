using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

[System.Serializable]
public class NodeInfo
{
    [SerializeField] private string _cellName;
    
    [SerializeField] private Field _field;
    
    [SerializeField] private bool _isRight;
    [SerializeField] private bool _isLeft;
    [SerializeField] private bool _isUp;
    [SerializeField] private bool _isDown;
    
    public string CellName => _cellName;
    public Field Field => _field;
}
