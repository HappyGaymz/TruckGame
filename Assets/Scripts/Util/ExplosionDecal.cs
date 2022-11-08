using UnityEngine;

public class ExplosionDecal : MonoBehaviour
{
    [SerializeField] GameObject[] decals;
    private void Start()
    {

        if (decals.Length == 0)
            return;
        var obj = decals[Random.Range(0, decals.Length)];
        var pos = new Vector3(transform.position.x, 0.01f, transform.position.z);
        var rot = Quaternion.Euler(90, Random.Range(0, 360), 0);
        //transform.position = pos;
        Instantiate(obj, pos, rot);
    }
}
