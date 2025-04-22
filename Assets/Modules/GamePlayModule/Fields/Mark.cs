using UnityEngine;

public class Mark : MonoBehaviour
{
    [SerializeField] private ColorType _color;
    
    public ColorType Color => _color;
}
