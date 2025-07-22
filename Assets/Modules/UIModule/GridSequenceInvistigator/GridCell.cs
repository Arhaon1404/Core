using UnityEngine;

public class GridCell : MonoBehaviour
{
    [SerializeField] private SequenceMark _mark;
    
    public SequenceMark Mark => _mark;

    public void SetMark(SequenceMark mark)
    {
        _mark = mark;
    }

    public void ResetMark()
    {
        _mark = null;
    }
}
