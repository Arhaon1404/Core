using System;
using UnityEngine;

public class СlickHandler : MonoBehaviour, IInputSource
    {
        [SerializeField] private LevelAStarProcceder _levelAStarProcceder;
        [SerializeField] private VictoryFieldStorage _victoryFieldStorage;

        private LevelStateMachine _levelStateMachine;
        private FieldSelector _fieldSelector;
        public event Action<GameObject> GottenHit;
        
        private void Awake()
        {
            _fieldSelector = new FieldSelector(this);
            _levelStateMachine = new LevelStateMachine(_fieldSelector,_levelAStarProcceder,_victoryFieldStorage);
            
            _levelStateMachine.EnterIn<StateWaitingFields>();
        }

        private void OnEnable()
        {
            _fieldSelector.Enable();
        }

        private void OnDisable()
        {
            _fieldSelector.Disable();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GottenHit?.Invoke(hit.collider.gameObject);
                }
            }
        }
    }

    

