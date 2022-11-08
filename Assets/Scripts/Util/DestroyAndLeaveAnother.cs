using UnityEngine;

public class DestroyAndLeaveAnother : MonoBehaviour
{
    public float damage = 3;
    [SerializeField] GameObject secondary;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            return;
        if (collision.TryGetComponent(out Damagable damagable))
        {
            damagable.TakeDamage(damage);
            Destroy(gameObject);
            Instantiate(secondary, transform.position, transform.rotation);
        }
    }
}
