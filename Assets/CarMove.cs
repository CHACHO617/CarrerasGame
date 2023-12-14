using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float acceleration = 5f; // Ajusta la velocidad de aceleración
    public float maxSpeed = 10f; // Ajusta la velocidad máxima del carro
    public float rotationSpeed = 100f; // Ajusta la velocidad de rotación del carro
    public float deceleration = 5f; // Ajusta la desaceleración cuando se deja de presionar las teclas de movimiento
    public float reverseDecelerationMultiplier = 2f; // Ajusta el multiplicador de desaceleración al retroceder

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
            // Si se presiona una tecla de movimiento, acelerar gradualmente hacia adelante o hacia atrás
            float desiredSpeed = maxSpeed * moveInput;

            if (Mathf.Sign(desiredSpeed) != Mathf.Sign(currentSpeed) && moveInput != 0)
            {
                // Si se presiona la tecla opuesta a la dirección actual del movimiento, desacelerar más rápido
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

        // Rotación del carro
        float rotateInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotateInput * rotationSpeed * Time.fixedDeltaTime);
    }
}