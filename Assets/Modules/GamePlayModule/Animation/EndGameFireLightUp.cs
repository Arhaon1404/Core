using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameFireLightUp : MonoBehaviour
{
    [SerializeField] private Explosion _explosion;
    [SerializeField] private Fire _endGameFire;

    public Explosion Explosion => _explosion;
    public Fire EndGameFire => _endGameFire;

    public void LightUp()
    {
        Explosion currentExplosion = Instantiate(_explosion);
        Fire currentFire = Instantiate(_endGameFire);
        
        currentExplosion.ParticleSystem.Stop();
        currentFire.ParticleSystem.Stop();
        
        currentExplosion.transform.position = transform.position;
        currentExplosion.ParticleSystem.Play();
        
        currentFire.transform.position = transform.position;
        currentFire.ParticleSystem.Play();
    }
}
