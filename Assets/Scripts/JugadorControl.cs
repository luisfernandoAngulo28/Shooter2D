using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.Mathematics;

public class JugadorControl : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 6f;
    public float fuerzaSalto = 12f;

    [Header("Detección de suelo")]
    public Transform chequeoSuelo;
    public float radioChequeo = 0.2f;
    public LayerMask capaSuelo;

    [Header("Disparo")]
    public GameObject Balaprefab;
    public Transform puntoDisparo;
    public float cadenciaDisparo = 0.25f;//el tiempo entre disparos en segundos

    [Header("Granada")]
    public GameObject granadaPrefab;
    public Vector2 fuerzaLanzamientoGranada = new Vector2(7f, 9f);

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool enSuelo;
    private bool mirandoDerecha = true;

    private float tiempoProximoDisparo = 0f;    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float movimientoHorizontal = 0f;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            movimientoHorizontal = -1f;
        }
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                movimientoHorizontal = 1f;
            }
    
        
        // movimiento horizontal:GetAxis devuelve un valor entre -1 y 1 
        // dependiendo de la tecla presionada
        //GetAxisRaw son las flechas de izquierda y derecha o A y D
        //float movimientoHorizontal = Input.GetAxisRaw("Horizontal"); 
        //solo se mueve de manera horizontal, no vertical
        rb.linearVelocity = new Vector2(movimientoHorizontal * velocidad, rb.linearVelocity.y);
        
        if (movimientoHorizontal > 0 && !mirandoDerecha)
        {
            Voltear();
        }
        else if (movimientoHorizontal < 0 && mirandoDerecha)
        {
            Voltear();
        }
        //esta tocando el suelo?
        enSuelo = Physics2D.OverlapCircle(chequeoSuelo.position, radioChequeo, capaSuelo);
        // saltar solo si esta tocando el suelo y presiona la tecla de salto
        if (Keyboard.current.spaceKey.wasPressedThisFrame && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        }
        // Disparo de bala
        if (Keyboard.current.xKey.wasPressedThisFrame && Time.time >= tiempoProximoDisparo)
        {
            Disparar();
            tiempoProximoDisparo = Time.time + cadenciaDisparo;
        }
        // Lanzamiento de granada
        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            LanzarGranada();
        }

    }

    void Disparar()
    {
        GameObject bala = Instantiate(
                            Balaprefab, 
                            puntoDisparo.position, 
                            Quaternion.identity
                        );
        bala.GetComponent<Bala>().Lanzar(mirandoDerecha ? 1f : -1f);            
        /*Bala balaScript = bala.GetComponent<Bala>();
        if (balaScript != null)
        {
            float direccion = mirandoDerecha ? 1f : -1f;
            balaScript.Lanzar(direccion);
        }*/
    }

    void LanzarGranada()
    {
        GameObject granada = Instantiate(
                                granadaPrefab, 
                                puntoDisparo.position, 
                                Quaternion.identity
                            );
        float direccion = mirandoDerecha ? 1f : -1f;
        Vector2 fuerzaLanzamiento = new Vector2(fuerzaLanzamientoGranada.x * direccion,
                                                fuerzaLanzamientoGranada.y);
        granada.GetComponent<Granada>().Lanzar(fuerzaLanzamiento);
        /*                    
        Granada granadaScript = granada.GetComponent<Granada>();
        if (granadaScript != null)
        {
            Vector2 fuerzaLanzamiento = new Vector2(mirandoDerecha ? fuerzaLanzamientoGranada.x : -fuerzaLanzamientoGranada.x, fuerzaLanzamientoGranada.y);
            granadaScript.Lanzar(fuerzaLanzamiento);
        }*/
    }

    void Voltear()
    {
        mirandoDerecha = !mirandoDerecha;
        sr.flipX = !sr.flipX;
        if(puntoDisparo != null)
        {
            Vector3 escala = puntoDisparo.localScale;
            escala.x =Mathf.Abs(escala.x) * (mirandoDerecha ? 1f : -1f);
            puntoDisparo.localScale = escala;
        }
    }
    // dibujar el circulo de detección del suelo en la escena para depuración
    void OnDrawGizmosSelected()
    {
        if (chequeoSuelo == null)
        {
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(chequeoSuelo.position, radioChequeo);
        

    }
}
