using UnityEngine;

public class CheckForWin : MonoBehaviour
{
    [SerializeField] IntegerVariable collectedBoxes;
    [SerializeField] IntegerVariable minBoxForWin;
    [SerializeField] GameEvent winEvent;

    bool won = false;

    public void Check()
    {
        if (won)
            return;
        if (collectedBoxes.Value >= minBoxForWin.Value)
        {
            won = true;
            winEvent.Raise();
        }
    }
}
