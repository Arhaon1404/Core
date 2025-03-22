using System.Collections.Generic;
using UnityEngine;

public class ConnectionLine : MonoBehaviour
{
    [SerializeField] private List<ColorType> _aisleСolors = new List<ColorType>();

    public List<ColorType> AisleColors => _aisleСolors;
    
    public void TurnOff(ConnectionLine verifiableConnectionLine)
    {
        if(verifiableConnectionLine == this)
            gameObject.SetActive(false);
    }
    
    public void TurnOn()
    {
        gameObject.SetActive(true);
    }
}
