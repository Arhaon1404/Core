using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private Connection[] _connections;
    [SerializeField] private Crystal _crystalOnField;
    [SerializeField] private CenterPoint _centerPoint;

    private void Awake()
    {
        
    }
}
