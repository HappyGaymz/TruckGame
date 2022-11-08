using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConfusionDealer : MonoBehaviour
{
    List<IConfusable> affectedObjects = new List<IConfusable>();
    [SerializeField] bool repeating;
    [SerializeField] UnityEvent onTrigger;
    public void ResetList()
    {
        affectedObjects.Clear();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Portal"))
            return;
        onTrigger.Invoke();
        var confusable = other.GetComponentInParent<IConfusable>();
        if (confusable != null)
        {
            if (repeating)
                confusable.Confused();
            else if (!affectedObjects.Contains(confusable))
            {
                affectedObjects.Add(confusable);
                confusable.Confused();
            }
        }
    }
}
