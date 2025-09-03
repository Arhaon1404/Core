using System;
using UnityEngine;

public class CameraPositioner : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private MapGenerator _mapGenerator;
    [SerializeField] private Vector3 _firstPosition;
    [SerializeField] private Vector3 _secondPosition;
    [SerializeField] private Vector3 _thirdPosition;
    [SerializeField] private Vector3 _fourthPosition;
    private int _mapWidth;
    private int _mapHeight;

    public void Initialize()
    {
        _mapWidth = _mapGenerator.FilledMap.GetLength(0);
        _mapHeight = _mapGenerator.FilledMap.GetLength(1);

        int maxLength;
        
        if (_mapWidth >= _mapHeight)
        {
            maxLength = _mapWidth;
        }
        else
        {
            maxLength = _mapHeight;
        }
        
        SetCameraPosition(maxLength);
    }

    private void SetCameraPosition(int lenght)
    {
        const int firstType = 2;
        const int secondType = 3;
        const int thirdType = 4;
        const int fourthType = 5;
        
        switch(lenght)
        {
            case firstType:
                _camera.transform.position = _firstPosition;
                break;
            case secondType:
                _camera.transform.position = _secondPosition;
                break;
            case thirdType:
                _camera.transform.position = _thirdPosition;
                break;
            case fourthType:
                _camera.transform.position = _fourthPosition;
                break;
            default:
                throw new ArgumentException(nameof(lenght));
                break;
        }
    }
}
