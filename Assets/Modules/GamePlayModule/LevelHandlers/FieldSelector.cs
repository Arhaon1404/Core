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
            
            ChangeStateFeaturesField(false);
            
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
                PreliminaryFieldCheck(_state,field);
                break;
            case State.HasStart:
                PreliminaryFieldCheck(_state,field);
                break;
        }
    }

    private void PreliminaryFieldCheck(State state,Field field)
    {
        if (field != null)
        {
            if (state == State.HasStart)
            {
                HandleStateHasStart(field);
            }
            else
            {
                if (field.CrystalOnField != null)
                {
                    if (field.CrystalOnField.IsActiveCrystal)
                    {
                        HandleStateNone(field);
                    }
                }
                else
                {
                    HandleStateNone(field);
                }
            }
        }
    }
    
    private void HandleStateNone(Field field)
    {
        _startField = field;
        _startField.ChangeColorFirstSelectField();

        ChangeStateFeaturesField(true);
            
        if (_startField.CrystalOnField)
            ChangeOutlineStateCrystal(_startField.CrystalOnField,true);
                
        _state = State.HasStart;
        
        StateUpdated?.Invoke(_state, _startField, _endField);
    }
    
    private void HandleStateHasStart(Field field)
    {
        if (_startField != field)
        {
            _endField = field;
            _endField.ChangeColorSecondSelectField();
            _state = State.HasEnd;
        }
        else
        {
            _state = State.None;
            _startField.ResetColorChanges();
            
            ChangeStateFeaturesField(false);
            
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

    private void ChangeStateFeaturesField(bool isEnabled)
    {
        if (_startField is RotateField)
        {
            if (isEnabled)
            {
                RotateField rotateField = (RotateField)_startField;
                rotateField.PlayBlinker();
            }
            else
            {
                RotateField rotateField = (RotateField)_startField;
                rotateField.StopBlinker();
            }
        }

        if (_startField is DisappearingField)
        {
            if (isEnabled)
            {
                DisappearingField disappearingField = (DisappearingField)_startField;
                disappearingField.PlayBlinker();
            }
            else
            {
                DisappearingField disappearingField = (DisappearingField)_startField;
                disappearingField.StopBlinker();
            }
        }
        
        if (_startField is DisapearConnectRotateField)
        {
            if (isEnabled)
            {
                DisapearConnectRotateField disappearingField = (DisapearConnectRotateField)_startField;
                disappearingField.PlayBlinker();
            }
            else
            {
                DisapearConnectRotateField disappearingField = (DisapearConnectRotateField)_startField;
                disappearingField.StopBlinker();
            }
        }
    }
}
