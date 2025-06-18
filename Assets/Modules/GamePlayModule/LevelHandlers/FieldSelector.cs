using System;
using UnityEngine;

public class FieldSelector
{
    private readonly IInputSource _inputSource;
        
    private Field _startField;
    private Field _endField;
    
    private State _state;
    
    public Action<State, Field, Field> StateUpdated;
    
    public FieldSelector(IInputSource inputSource)
    {
        _inputSource = inputSource;
    }
        
    public void Enable() => 
        _inputSource.GottenHit += OnGottenHit;

    public void Disable() => 
        _inputSource.GottenHit -= OnGottenHit;
    
    public void Clear()
    {
        if (_startField || _endField)
        {
            _startField.ResetColorChanges();
            
            if (_startField.CrystalOnField)
                ChangeOutlineStateCrystal(_startField.CrystalOnField,false);
            
            _endField.ResetColorChanges();
            
            if (_endField.CrystalOnField)
                ChangeOutlineStateCrystal(_endField.CrystalOnField,false);
        }
        
        _state = State.None;
        
        _startField = null;
        _endField = null;
    }
    
    private void OnGottenHit(GameObject hitTarget)
    {
        hitTarget.TryGetComponent(out Field field);
        
        switch (_state)
        {
            case State.None:
                HandleStateNone(field);
                break;
            case State.HasStart:
                HandleStateHasStart(field);
                break;
        }
    }
    
    private void HandleStateNone(Field field)
    {
        if (field != null)
        {
            _startField = field;
            _startField.ChangeColorFirstSelectField();

            if (_startField.CrystalOnField)
                ChangeOutlineStateCrystal(_startField.CrystalOnField,true);
                
            _state = State.HasStart;
        }

        StateUpdated?.Invoke(_state, _startField, _endField);
    }
    
    private void HandleStateHasStart(Field field)
    {
        if (field != null && _startField != field)
        {
            _endField = field;
            _endField.ChangeColorSecondSelectField();
            _state = State.HasEnd;
        }
        else
        {
            _state = State.None;
            _startField.ResetColorChanges();
            
            if (_startField.CrystalOnField)
                ChangeOutlineStateCrystal(_startField.CrystalOnField,false);
            
            _startField = null;
        }
        
        StateUpdated?.Invoke(_state, _startField, _endField);
    }

    private void ChangeOutlineStateCrystal(Crystal crystal,bool isEnabled)
    {
        if (isEnabled)
        {
            crystal.TurnOnOutline();
        }
        else
        {
            crystal.TurnOffOutline();
        }
    }
}
