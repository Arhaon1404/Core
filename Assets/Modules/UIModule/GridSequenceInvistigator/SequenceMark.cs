using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class SequenceMark : MonoBehaviour
{
    [SerializeField] private ColorType _colorType;
    [SerializeField] private Color _startColor;
    private Image _image;
    
    public ColorType ColorType => _colorType;
    public Color StartColor => _startColor;
    
    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void ChangeColor(ColorType colorType,Color color)
    {
        _colorType = colorType;
        
        _image.color = color;
    }
}
