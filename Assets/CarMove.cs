using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float acceleration = 5f; // Ajusta la velocidad de aceleraci�n
    public float maxSpeed = 10f; // Ajusta la velocidad m�xima del carro
    public float rotationSpeed = 100f; // Ajusta la velocidad de rotaci�n del carro
    public float deceleration = 5f; // Ajusta la desaceleraci�n cuando se deja de presionar las teclas de movimiento
    public float reverseDecelerationMultiplier = 2f; // Ajusta el multiplicador de desaceleraci�n al retroceder

    private Rigidbody rb;
    private float currentSpeed = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        // Movimiento del carro
        float moveInput = Input.GetAxis("Vertical");

        if (moveInput != 0)
        {
            // Si se presiona una tecla de movimiento, acelerar gradualmente hacia adelante o hacia atr�s
            float desiredSpeed = maxSpeed * moveInput;

            if (Mathf.Sign(desiredSpeed) != Mathf.Sign(currentSpeed) && moveInput != 0)
            {
                // Si se presiona la tecla opuesta a la direcci�n actual del movimiento, desacelerar m�s r�pido
                currentSpeed = Mathf.MoveTowards(currentSpeed, desiredSpeed, deceleration * reverseDecelerationMultiplier * Time.fixedDeltaTime);
            }
            else
            {
                currentSpeed = Mathf.MoveTowards(currentSpeed, desiredSpeed, acceleration * Time.fixedDeltaTime);
            }
        }
        else
        {
            // Si no se presiona ninguna tecla de movimiento, desacelerar gradualmente
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.fixedDeltaTime);
        }

        // Aplicar la velocidad al Rigidbody para mover el carro
        rb.velocity = transform.forward * currentSpeed;

        // Rotaci�n del carro
        float rotateInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotateInput * rotationSpeed * Time.fixedDeltaTime);
    }
}