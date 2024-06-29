using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public float jumpForce = 10f;
    private Vector2 movement;
    private Animator animator;
    private bool facingRight = true; // Verificar se o personagem está olhando para a direita

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Captura as entradas de movimento apenas no eixo horizontal
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = 0f; // Garante que o movimento vertical seja zero

        // Atualiza a velocidade no Animator
        animator.SetFloat("Speed", Mathf.Abs(movement.x));

        // Inverte a sprite quando o personagem se move para a esquerda/direita
        if (movement.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (movement.x < 0 && facingRight)
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Move o personagem usando o Rigidbody2D
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    // Método para inverter a sprite
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}