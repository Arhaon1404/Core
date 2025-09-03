using DG.Tweening;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _backlightColor;
    [SerializeField] private Color _winningColor;
    [SerializeField] private Color _defaultEmissionColor;
    [SerializeField] private Color _backlightEmissionColor;
    [SerializeField] private Color _endEmissionColor;
    [SerializeField] private Color _selectEmissionColor;
    [SerializeField] private Color _winningEmmissionColor;
    
    public MeshRenderer MeshRenderer => _meshRenderer;

    private void Awake()
    {
        _defaultEmissionColor = _meshRenderer.material.GetColor("_EmissionColor");
    }

    public void ChangeColor(Color color, bool isActivateBacklight)
    {
        _meshRenderer.material.color = color;

        if (isActivateBacklight)
        {
            ActivateSelectionBacklight();
        }
        else
        {
            DeactivateSelectionBacklight();
        }
    }

    public void ActivateEndBacklight()
    {
        _meshRenderer.material.DOColor(_endEmissionColor,"_EmissionColor" ,0.5f);
    }

    public void ActivateBacklight()
    {
        _meshRenderer.material.color = _backlightColor;
        
        _meshRenderer.material.DOColor(_backlightEmissionColor,"_EmissionColor" ,0.5f);
    }

    public void DeactivateBacklight()
    {
        _meshRenderer.material.color = _defaultColor;
        
        _meshRenderer.material.DOColor(_defaultEmissionColor,"_EmissionColor" ,0.5f);
    }

    public void ActivateWinningBacklight()
    {
        _meshRenderer.material.color = _winningColor;
        
        _meshRenderer.material.DOColor(_winningEmmissionColor,"_EmissionColor" ,0.5f);
    }

    private void ActivateSelectionBacklight()
    {
        _meshRenderer.material.DOColor(_selectEmissionColor,"_EmissionColor" ,0.5f);
    }

    private void DeactivateSelectionBacklight()
    {
        _meshRenderer.material.DOColor(_defaultEmissionColor,"_EmissionColor" ,0.5f);
    }
}
