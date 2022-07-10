using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpBox : MonoBehaviour
{
    [SerializeField] private int count;
    [SerializeField] TextMeshPro tmp;
    public int Count => count;
    public bool PickedUp = false;
    private void Awake()
    {
        tmp.text = count.ToString();
    }
}
