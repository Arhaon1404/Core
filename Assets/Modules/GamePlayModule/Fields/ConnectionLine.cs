using UnityEngine;

public class ConnectionLine : MonoBehaviour
{
    public void TurnOff(ConnectionLine verifiableConnectionLine)
    {
        if(verifiableConnectionLine == this)
            this.gameObject.SetActive(false);
    }
}
