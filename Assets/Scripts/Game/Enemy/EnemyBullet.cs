using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject Player;
    
    private Rigidbody2D rigidbody;
    
    private float timer;

    public float force;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        
        Vector3 direction = Player.transform.position - transform.position;
        rigidbody.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
        
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthController>().TakeDamage(20);
            Destroy(gameObject);
        }
    }
}
