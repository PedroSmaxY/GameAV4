using UnityEngine;

public class BossMeleeAttack : MonoBehaviour
{
    public float damage = 10f;           // Dano do ataque
    public float skillDamage = 20f;
    public float attackRange = 1.5f;       // Alcance do ataque
    public float attackRate = 100f;        // Taxa de ataque (ataques por segundo)
    private Animator animator;
    private System.Random random;
    private int count = 0;
    private Transform player;            // Referência ao jogador
    private bool playerInRange;          // Indica se o jogador está no alcance
    private float nextAttackTime = 2f;   // Tempo do próximo ataque

    void Start()
    {
        animator = GetComponent<Animator>();
        random = new System.Random();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Verifica se o jogador está no alcance
        playerInRange = Vector3.Distance(transform.position, player.position) <= attackRange;

        // Verifica se é hora de atacar
        if (playerInRange && Time.time >= nextAttackTime)
        {
            // Define o próximo tempo de ataque com base na taxa de ataque
            nextAttackTime = Time.time + 25f / attackRate;
            int randomInt = random.Next(11);
            Debug.Log(randomInt);

            if (randomInt <= 8)
            {
                // Chama o método para realizar o ataque
                if (count % 2 == 0)
                {
                    animator.SetTrigger("LowerCut");
                } 
                else
                {
                    animator.SetTrigger("UpperCut");
                }
                Attack();
                count++;
            }
            else
            {
                animator.SetTrigger("Skill");
            }
        }
    }

    void Attack()
    {
        // Aplica dano ao jogador
        // Aqui você pode adicionar lógica para reduzir a saúde do jogador, por exemplo
        // Neste exemplo, estamos apenas imprimindo uma mensagem
        Debug.Log("Boss atacou o jogador!");

        // Exemplo de como você pode aplicar dano ao jogador
        // Supondo que o jogador tenha um script de saúde (Health) associado
        // player.GetComponent<Health>().TakeDamage(damage);
    }
}