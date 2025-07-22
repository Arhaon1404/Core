using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class SequenceMark : MonoBehaviour
{
    [SerializeField] private ColorType _colorType;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _currentColor;
    private Renderer _renderer;
    
    public ColorType ColorType => _colorType;
    public Color StartColor => _startColor;
    
    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    public void ChangeColor(ColorType colorType,Color color)
    {
        _colorType = colorType;
        
        _renderer.material.SetColor("_Color", color);
        
        _renderer.material.SetColor("_EmissionColor", color);
        
        _currentColor = color;
    }
    
    public void ChangeAlphaColor(float multiplier)
    {
        Color color = new Color(_currentColor.r,_currentColor.g,_currentColor.b,_currentColor.a / multiplier);
        
        _renderer.material.SetColor("_Color", color);
    }
}
