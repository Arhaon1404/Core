using UnityEngine;

public class RealizerOtherFeatures : MonoBehaviour
{
    public void Realize(Field[,] _filledMap, NodeInfo[,] _map)
    {
        for (int i = 0; i < _filledMap.GetLength(0); i++)
        {
            for (int j = 0; j < _filledMap.GetLength(1); j++)
            {
                if(_filledMap[i,j] == null) continue;
                if (_filledMap[i,j] is StartField)
                {
                    RealizeFiaturesStartField((StartField)_filledMap[i,j],_map[i,j]);
                }
                else if (_filledMap[i,j] is RotateField)
                {
                    RealizeFiaturesRotateField((RotateField)_filledMap[i,j],_map[i,j]);
                }
                else
                {
                    RealizeFiaturesField(_filledMap[i, j], _map[i, j]);
                }
            }
        }
    }

    private void RealizeFiaturesStartField(StartField currentStartField, NodeInfo currentNode)
    {
        foreach (Connection connection in currentStartField.ActiveConnections)
        {
            Field anotherField = connection.ConnectionAnotherField.MotherField;
            
            connection.ConnectionAnotherField.ConnectionLine.gameObject.SetActive(false);
            
            anotherField.ActiveConnections.Remove(connection.ConnectionAnotherField);
        }

        bool isFirst = true;
        
        foreach (Core core in currentNode.ListCores)
        {
            Core instantiatedCore = Instantiate(core,currentStartField.CenterPoint.transform.position,Quaternion.identity);

            instantiatedCore.transform.SetParent(transform);
            
            if (isFirst)
            {
                currentStartField.SetStartCore(instantiatedCore);
                isFirst = false;
            }
            else
            {
                instantiatedCore.gameObject.SetActive(false);
            }

            currentStartField.ListCores.Add(instantiatedCore);
        }
    }

    private void RealizeFiaturesField(Field currentField, NodeInfo currentNode)
    {
        if (currentNode.CrystalOnField != null)
        {
            Crystal instantiatedCrystal = Instantiate(currentNode.CrystalOnField,currentField.CenterPoint.transform);
            
            instantiatedCrystal.transform.position = currentField.CenterPoint.transform.position;
            
            instantiatedCrystal.transform.SetParent(currentField.transform);
            
            currentField.SetCrystal(instantiatedCrystal);
        }

        if (currentNode.Mark != null)
        {
            Mark instantiatedMark = Instantiate(currentNode.Mark,currentField.transform);
            
            instantiatedMark.transform.localPosition = Vector3.zero;
            
            currentField.SetColor(instantiatedMark.Color);
        }
        
        if (currentNode.ColorsConnections != null)
        {
            foreach (Connection connection in currentField.ActiveConnections)
            {
                if (currentNode.ColorsConnections.ContainsKey(connection.ConnectionType))
                {
                    Transform currentTransform = connection.ConnectionLine.transform;
                    
                    Destroy(connection.ConnectionLine.gameObject);
                    
                    ConnectionLine newConnectionLine = Instantiate(currentNode.ColorsConnections[connection.ConnectionType]);
                    
                    newConnectionLine.transform.SetParent(connection.transform);
                    
                    newConnectionLine.transform.position = connection.ConnectionLineCenterPoint.transform.position;
                    newConnectionLine.transform.rotation = currentTransform.rotation;
                    
                    connection.SetNewConnectionLine(newConnectionLine);
                }
            }
        }
    }
    
    private void RealizeFiaturesRotateField(RotateField rotateField, NodeInfo nodeInfo)
    {
        foreach (Connection connection in rotateField.ActiveConnections)
        {
            rotateField.OrderAdjacentConnections.Add(connection);
        }

        RealizeFiaturesField(rotateField, nodeInfo);
    }
}
