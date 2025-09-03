using System;
using UnityEngine;

public class ClickHandler : MonoBehaviour, IInputSource
{
    [SerializeField] private LevelAStarProcceder _levelAStarProcceder;
    [SerializeField] private VictoryFieldStorage _victoryFieldStorage;
    [SerializeField] private Backlighter _backlighter;
        
    private LevelStateMachine _levelStateMachine;
    private FieldSelector _fieldSelector;

    private bool _isWokrs;
    
    public event Action<GameObject> GottenHit;
    
    public FieldSelector FieldSelector => _fieldSelector;
        
    public void Awake()
    {
        _fieldSelector = new FieldSelector(this);
        
        _levelStateMachine = new LevelStateMachine(this,_fieldSelector,_levelAStarProcceder,_victoryFieldStorage);
            
        _levelStateMachine.EnterIn<StateWaitingFields>();
        
        _isWokrs = true;
    }

    private void OnEnable()
    {
        _fieldSelector.Enable();
        _fieldSelector.StateNoneAchieved += TurnOn;
    }

    private void OnDisable()
    {
        _fieldSelector.StateNoneAchieved -= TurnOn;
        _fieldSelector.Disable();
    }
    
    private void Update()
    {
        if (_isWokrs)
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
    
    public void TurnOn()
    {
        _isWokrs = true;
    }
    
    public void TurnOff()
    {
        _isWokrs = false;
    }
}

    

