using UnityEngine;

public class AreaParticleSystem : MonoBehaviour
{
    [SerializeField] private ParticleSystem _areaParticleSystem;
    [SerializeField] private AreaSquare _areaSquare;
    [SerializeField] private AreaSmallPoints _areaSmallPoints;
    [SerializeField] private AreaLargePoints _areaLargePoints;
    [SerializeField] private Color _switchColor;
    
    public void Activate()
    {
        _areaParticleSystem.Play();
    }

    public void Deactivate()
    {
        _areaParticleSystem.Stop();
    }

    public void SwitchLightMode()
    {
        _areaParticleSystem.Clear();
        
        _areaSmallPoints.gameObject.SetActive(false);
        _areaLargePoints.gameObject.SetActive(false);

        float swithedStartLifeTime = 3f;
        
        _areaSquare.SetNewLifeTime(swithedStartLifeTime);

        ParticleSystem.MainModule main = _areaParticleSystem.main;

        swithedStartLifeTime = 5f;
        
        main.startLifetime = swithedStartLifeTime;
        
        float swithedDuration = 4f;
        
        main.duration = swithedDuration;
        
        int swithedMaxParticles = 5;
        
        main.maxParticles = swithedMaxParticles;
        
        main.startColor = _switchColor;
    }
}
