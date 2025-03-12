using UnityEngine;

public class ConnectionLine : MonoBehaviour
{
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
