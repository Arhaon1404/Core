using UnityEngine;

public class AreaSquare : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Color _switchColor;
    private ParticleSystem.MainModule _main;
    
    public void SetNewLifeTime(float lifetime)
    {
        _main = _particleSystem.main; 
        
        _main.startLifetime = new ParticleSystem.MinMaxCurve(lifetime);

        SetNewColor();
    }

    private void SetNewColor()
    {
        _main.startColor = _switchColor;
    }
}
