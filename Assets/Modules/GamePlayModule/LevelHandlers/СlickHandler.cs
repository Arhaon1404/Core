using System;
using UnityEngine;

public class СlickHandler : MonoBehaviour
    {
        [SerializeField] private Field _selectedFirstField;
        [SerializeField] private Field _selectedSecondField;
        [SerializeField] private LevelAStarProcceder _levelAStarProcceder;
        [SerializeField] private VictoryFieldStorage _victoryFieldStorage;

        private LevelStateMachine _levelStateMachine;
        public event Action<Field,Field> FieldsReceived;
    
        private void Awake()
        {
            _levelStateMachine = new LevelStateMachine(this,_levelAStarProcceder,_victoryFieldStorage);
        
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

        public void ClearSelectedFields()
        {
            _selectedFirstField = null;
            _selectedSecondField = null;
        }

        private void FindFields(RaycastHit hit)
        {
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

    

