using UnityEngine;

public class EnemyBomb : MonoBehaviour
{
    [SerializeField] 
    private float explosionRadius;
    [SerializeField] 
    private float damage;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthController>().TakeDamage(50);
            Destroy(gameObject);
        }
    }
}
