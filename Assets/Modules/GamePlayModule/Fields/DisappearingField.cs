
using UnityEngine;

public class DisappearingField : Field
{
    [SerializeField] ConnectionsBlinker _connectionsBlinker;

    public void PlayBlinker()
    {
        foreach (Connection connection in ActiveConnections)
        {
            connection.ConnectionLine.StartBlinking();
            connection.ConnectionAnotherField.ConnectionLine.StartBlinking();
        }
    }

    public void StopBlinker()
    {
        foreach (Connection connection in ActiveConnections)
        {
            connection.ConnectionLine.StopBlinking();
            connection.ConnectionAnotherField.ConnectionLine.StopBlinking();
        }
    }
}
