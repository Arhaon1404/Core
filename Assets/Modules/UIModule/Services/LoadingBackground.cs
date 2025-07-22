using UnityEngine;

public class LoadingBackground : MonoBehaviour
{
    public void TurnOn()
    {
        this.gameObject.SetActive(true);   
    }
    
    public void TurnOff()
    {
        this.gameObject.SetActive(false);
    }
}
