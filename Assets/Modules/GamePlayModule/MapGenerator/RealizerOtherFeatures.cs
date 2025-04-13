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

        foreach (Core core in currentNode.ListCores)
        {
            Core instantiatedCore = Instantiate(core,currentStartField.CenterPoint.transform.position,Quaternion.identity);

            instantiatedCore.transform.SetParent(transform);
            
            if (currentNode.ListCores[0] != core)
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
            
            instantiatedCrystal.transform.SetParent(transform);
            
            currentField.SetCrystal(instantiatedCrystal);
        }
    }
}
