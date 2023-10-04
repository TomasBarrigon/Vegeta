using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 direction;
    public int damageAmount = 10; // Daño del proyectil

    void Update()
    {
        // Mueve el proyectil en la dirección establecida
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }

void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Enemy"))
    {
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
        enemy.TakeDamage(damageAmount);
        gameObject.SetActive(false);
    }
     if (collision.gameObject.CompareTag("Cosa"))
    {
        gameObject.SetActive(false);
    }
}
}




