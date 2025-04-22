using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectLinker
{
    private Field currentField;
    private Field nextField;
    
    public void ConnectConnections(Field[,] mapFields,NodeInfo[,] _map)
    {
        ConnectInWidth(mapFields);
        ConnectInHeight(mapFields);
        RemovingUnnecessaryConnections(mapFields, _map);
    }

    private void ConnectInWidth(Field[,] mapFields)
    {
        for (int i = 0; i < mapFields.GetLength(0); i++)
        {
            for (int j = 0; j < mapFields.GetLength(1); j++)
            {
                if (mapFields[i, j] == null) continue;
                if (j != (mapFields.GetLength(1) - 1))
                {
                    currentField = mapFields[i, j];
                    nextField = mapFields[i, j + 1];

                    if (nextField != null)
                    {
                        Connection currentFieldRightConnection = currentField.ActiveConnections.Find(connection => connection.ConnectionType == ConnectionType.right);
                        Connection currentFieldLeftConnection = nextField.ActiveConnections.Find(connection => connection.ConnectionType == ConnectionType.left);
                        
                        currentFieldRightConnection.gameObject.SetActive(true);
                        currentFieldLeftConnection.gameObject.SetActive(true);
                        
                        currentFieldRightConnection.SetConnectionAnotherField(currentFieldLeftConnection);
                        currentFieldLeftConnection.SetConnectionAnotherField(currentFieldRightConnection);
                    }
                }
            }
        }
    }
    
    private void ConnectInHeight(Field[,] mapFields)
    {
        for (int i = 0; i < mapFields.GetLength(0); i++)
        {
            for (int j = 0; j < mapFields.GetLength(1); j++)
            {
                if (mapFields[i, j] == null) continue;
                if (i != (mapFields.GetLength(0) - 1))
                {
                    currentField = mapFields[i, j];
                    nextField = mapFields[i + 1, j];

                    if (nextField != null)
                    {
                        Connection currentFieldDownConnection = currentField.ActiveConnections.Find(connection => connection.ConnectionType == ConnectionType.down);
                        Connection currentFieldUpConnection = nextField.ActiveConnections.Find(connection => connection.ConnectionType == ConnectionType.up);

                        currentFieldDownConnection.gameObject.SetActive(true);
                        currentFieldUpConnection.gameObject.SetActive(true);
                        
                        currentFieldDownConnection.SetConnectionAnotherField(currentFieldUpConnection);
                        currentFieldUpConnection.SetConnectionAnotherField(currentFieldDownConnection);
                    }
                }
            }
        }
    }
    
    private void RemovingUnnecessaryConnections(Field[,] mapFields,NodeInfo[,] _map)
    {
        for (int i = 0; i < mapFields.GetLength(0); i++)
        {
            for (int j = 0; j < mapFields.GetLength(1); j++)
            {
                if (mapFields[i, j] == null) continue;
                for(int h = mapFields[i,j].ActiveConnections.Count - 1; h > -1; h--)
                {
                    Connection connectionToRemove = mapFields[i, j].ActiveConnections[h].ConnectionAnotherField;
                    
                    if (connectionToRemove == null)
                    {
                        mapFields[i, j].ActiveConnections.Remove(mapFields[i, j].ActiveConnections[h]);
                    }
                }

                if (_map[i, j].ConnectionsToRemove.Count != 0)
                {
                    foreach (ConnectionType connectionType in _map[i,j].ConnectionsToRemove)
                    {
                        Connection connectionToRemove = mapFields[i, j].ActiveConnections.Find(connection => connection.ConnectionType == connectionType);
                        
                        connectionToRemove.MotherField.ActiveConnections.Remove(connectionToRemove);
                        connectionToRemove.gameObject.SetActive(false);
                    }
                }

                if (_map[i, j].ConnectionsToHide.Count != 0)
                {
                    foreach (ConnectionType connectionType in _map[i,j].ConnectionsToHide)
                    {
                        Connection connectionToHide = mapFields[i, j].ActiveConnections.Find(connection => connection.ConnectionType == connectionType);
                        
                        connectionToHide.ConnectionAnotherField.ConnectionLine.gameObject.SetActive(false);
                        connectionToHide.ConnectionLine.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}