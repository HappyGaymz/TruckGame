using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollector : MonoBehaviour
{
    [SerializeField] GameObject boxPrefab;
    [SerializeField] Transform boxSpawnPoint;
    [SerializeField] float delayBetween;
    Rigidbody truckRigidbody;
    WaitForSeconds wait;
    private void Awake()
    {
        wait = new WaitForSeconds(delayBetween);
        truckRigidbody = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.TryGetComponent(out PickUpBox pickUp))
        {
            if (pickUp.PickedUp)
                return;
            pickUp.PickedUp = true;
            StartCoroutine(SpawnBoxes(pickUp.Count));
            Destroy(pickUp.gameObject);
        }
    }

    private IEnumerator SpawnBoxes(int count)
    {
        int spawn = 0;
        while(spawn < count)
        {
            spawn++;
            var rb = Instantiate(boxPrefab, boxSpawnPoint.position,Random.rotation).GetComponent<Rigidbody>();
            rb.velocity = truckRigidbody.velocity;
            yield return wait;
        }
    }
}
