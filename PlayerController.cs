using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject projectilePrefab;
    public int maxHealth = 100; // Vida máxima del personaje
    public int currentHealth;   // Vida actual del personaje
    public Text gameOverText;

    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);


        // Cambiar el sprite según la dirección del movimiento
        if (movement.y > 0)
        {
            spriteRenderer.sprite = spriteUp;
        }
        else if (movement.y < 0)
        {
            spriteRenderer.sprite = spriteDown;
        }
        else if (movement.x < 0)
        {
            spriteRenderer.sprite = spriteLeft;
        }
        else if (movement.x > 0)
        {
            spriteRenderer.sprite = spriteRight;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        if (projectilePrefab != null) // Verifica si el Prefab aún existe
    {
       // Obtener la posición del ratón en el mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcular la dirección del disparo
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Crear el proyectil
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Asignar la dirección al proyectil
        projectile.GetComponent<ProjectileScript>().SetDirection(direction);
    }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            ShowGameOver();
            // Aquí puedes agregar código para lo que ocurre cuando el personaje muere
            // Por ejemplo, cargar un nivel de reinicio o mostrar un mensaje de game over.
            // También puedes respawnear al personaje, reiniciar la partida, etc.
        }
    }

    void ShowGameOver()
{
    gameOverText.gameObject.SetActive(true);
}


    }



