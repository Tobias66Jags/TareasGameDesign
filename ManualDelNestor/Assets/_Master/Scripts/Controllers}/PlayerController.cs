using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float fuerzaSalto = 10.0f;
    private bool enElSuelo = true;
    private Rigidbody2D rb;
    private int playerIndex;

    private static int playerIndex2 = 0;

    void Start()
    {
        rb = GetComponent < Rigidbody2D>();

        if (playerIndex2 == 0)
        {
            playerIndex = 1;
            playerIndex2 = 2;
        }
        else
        {
            playerIndex = playerIndex2;
            playerIndex2++;
        }
    }

    void Update()
    {
        // Movimiento horizontal
        float movimientoHorizontal = 0f;

        if (playerIndex == 1)
        {
            movimientoHorizontal = Input.GetAxis("Horizontal");
        }
        else if (playerIndex == 2)
        {
            movimientoHorizontal = Input.GetAxis("Horizontal2");
        }

        Vector2 velocidad = rb.velocity;
        velocidad.x = movimientoHorizontal * velocidadMovimiento;
        rb.velocity = velocidad;

        // Salto
        if (enElSuelo && ((playerIndex == 1 && Input.GetKeyDown(KeyCode.Space)) || (playerIndex == 2 && Input.GetKeyDown(KeyCode.C))))
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            enElSuelo = false;
        }
        if (enElSuelo && ((playerIndex == 2 && Input.GetKeyDown(KeyCode.C)) || (playerIndex == 2 && Input.GetKeyDown(KeyCode.C))))
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            enElSuelo = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el jugador está en el suelo
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enElSuelo = true;
        }
    }
}