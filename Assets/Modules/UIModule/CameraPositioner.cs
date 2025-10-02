using System;
using UnityEngine;

public class CameraPositioner : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private MapGenerator _mapGenerator;
    [SerializeField] private Vector3 _firstPositionHorizontalPosition;
    [SerializeField] private Vector3 _secondPositionHorizontalPosition;
    [SerializeField] private Vector3 _thirdPositionHorizontalPosition;
    [SerializeField] private Vector3 _fourthPositionHorizontalPosition;
    [SerializeField] private Quaternion _fourthRotationHorizontalPosition;
    [SerializeField] private Vector3 _firstPositionVerticalPosition;
    [SerializeField] private Vector3 _secondPositionVerticalPosition;
    [SerializeField] private Vector3 _thirdPositionVerticalPosition;
    [SerializeField] private Vector3 _fourthPositionVerticalPosition;
    [SerializeField] private Quaternion _fourthRotationVerticalPosition;
    [SerializeField] private int _currentScreenWidth;
    [SerializeField] private int _currentScreenHeight;
    
    private int _mapWidth;
    private int _mapHeight;

    private void Update()
    {
        if (_currentScreenWidth != Screen.width || _currentScreenHeight != Screen.height)
        {
            Initialize();
        }
    }

    public void Initialize()
    {
        _mapWidth = _mapGenerator.FilledMap.GetLength(0);
        _mapHeight = _mapGenerator.FilledMap.GetLength(1);

        _currentScreenWidth = Screen.width;
        _currentScreenHeight = Screen.height;
        
        int maxLength;
        
        if (_mapWidth >= _mapHeight)
        {
            maxLength = _mapWidth;
        }
        else
        {
            maxLength = _mapHeight;
        }
        
        if (Screen.width > Screen.height)
        {
            SetCameraHorizontalPosition(maxLength);
        }
        else
        {
            SetCameraVerticalPosition(maxLength);
        }
    }
    
    private void SetCameraHorizontalPosition(int lenght)
    {
        const int firstType = 2;
        const int secondType = 3;
        const int thirdType = 4;
        const int fourthType = 5;
        
        switch(lenght)
        {
            case firstType:
                _camera.transform.position = _firstPositionHorizontalPosition;
                break;
            case secondType:
                _camera.transform.position = _secondPositionHorizontalPosition;
                break;
            case thirdType:
                _camera.transform.position = _thirdPositionHorizontalPosition;
                break;
            case fourthType:
                _camera.transform.position = _fourthPositionHorizontalPosition;
                _camera.transform.rotation = _fourthRotationHorizontalPosition;
                break;
            default:
                throw new ArgumentException(nameof(lenght));
                break;
        }
    }
    
    private void SetCameraVerticalPosition(int lenght)
    {
        const int firstType = 2;
        const int secondType = 3;
        const int thirdType = 4;
        const int fourthType = 5;
        
        switch(lenght)
        {
            case firstType:
                _camera.transform.position = _firstPositionVerticalPosition;
                break;
            case secondType:
                _camera.transform.position = _secondPositionVerticalPosition;
                break;
            case thirdType:
                _camera.transform.position = _thirdPositionVerticalPosition;
                break;
            case fourthType:
                _camera.transform.position = _fourthPositionVerticalPosition;
                _camera.transform.rotation = _fourthRotationVerticalPosition;
                break;
            default:
                throw new ArgumentException(nameof(lenght));
                break;
        }
    }
}
