using UnityEngine;

public class BackgroundRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private Transform _background;

    private void Start()
    {
        _background = transform;
    }

    private void Update()
    {
        _background.Rotate(0,_rotationSpeed, 0);
    }
}
