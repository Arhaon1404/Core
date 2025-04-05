using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldsPlacer : MonoBehaviour
{
    public void PlaceField(NodeInfo[,] map,float marginSpacing)
    {
        Field[,] mapCreatedFields = new Field[map.GetLength(0), map.GetLength(1)];
        
        GameObject fieldsMap = new GameObject("Map");
        
        fieldsMap.transform.SetParent(transform);
        
        fieldsMap.transform.position = Vector3.zero;
        
        float centerX = CalculateCenterPoint(map.GetLength(0),marginSpacing);
        float centerZ = CalculateCenterPoint(map.GetLength(1),marginSpacing);
        
        transform.position = new Vector3(transform.position.x - centerX, transform.position.y, transform.position.z - centerZ);
        
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i, j].Field != null)
                {
                    float coordinateX = fieldsMap.transform.localPosition.x + (i * marginSpacing);
                    float coordinateZ = fieldsMap.transform.localPosition.z + (j * marginSpacing);
                    
                    Vector3 coordinatesCreateField = new Vector3(coordinateX ,fieldsMap.transform.localPosition.y , coordinateZ);
                    
                    Field newField = Instantiate(map[i,j].Field,coordinatesCreateField,Quaternion.identity,fieldsMap.transform);

                    newField.name = map[i, j].CellName;
                    
                    mapCreatedFields[i,j] = newField;
                }
            }
        }
        
        fieldsMap.transform.localPosition = transform.position;
    }

    private float CalculateCenterPoint(int countLenght, float marginSpacing)
    {
        float standartFieldScale = 4f;
        
        float centerShift = ((countLenght * marginSpacing) - standartFieldScale) / 2;
        
        return centerShift;
    }
}
