using UnityEngine;

public class Granada : MonoBehaviour
{
    public  float tiempoExplosión = 1.5f; // Tiempo en segundos antes de que la granada explote
    public float radioExplosión = 2.5f; // Radio de la explosión  
    public int daño = 3; // Daño que inflige la granada
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Explotar", tiempoExplosión); // Llama al método Explotar después de tiempoExplosión segundos
    }


    public void Lanzar(Vector2 fuerza)
    {
        GetComponent<Rigidbody2D>().AddForce(fuerza, ForceMode2D.Impulse); // Aplica una fuerza a la granada para lanzarla
    }

    void Explotar()
    {
        // Detecta todos los colliders dentro del radio de explosión
        Collider2D[] objetosAfectados = Physics2D.OverlapCircleAll(
                                            transform.position, 
                                            radioExplosión
                                        );

        foreach (Collider2D objeto in objetosAfectados)
        {
            if (objeto.CompareTag("Enemigo") )
            {                            
                    Vida vida = objeto.GetComponent<Vida>();
                    if (vida != null)
                    {
                        vida.RecibirDaño(daño); // Aplica daño al objeto afectado
                    }                
            }
        }

        Destroy(gameObject); // Destruye la granada después de la explosión
    }

    void OnDrawGizmosSelected()
    {
        // Dibuja un gizmo en el editor para visualizar el radio de explosión
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioExplosión);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
