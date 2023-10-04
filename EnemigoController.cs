using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    public Transform target;
    public int maxHealth = 50; // Vida máxima del enemigo
    public int currentHealth;  // Vida actual del enemigo
    public int damageAmount = 10; // Cantidad de daño que hace el enemigo

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        player.TakeDamage(damageAmount);
    }
    if (collision.gameObject.CompareTag("Proyectil"))
    {
        TakeDamage(damageAmount);
        Destroy(collision.gameObject);
    }
    }



        public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            // Aquí puedes agregar código para lo que ocurre cuando el personaje muere
            // Por ejemplo, cargar un nivel de reinicio o mostrar un mensaje de game over.
            // También puedes respawnear al personaje, reiniciar la partida, etc.
        }
    }
}
