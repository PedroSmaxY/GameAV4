using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyFollow : MonoBehaviour
{
    public Transform hero;  // Referência ao herói
    public float speed = 1.5f; // Velocidade do inimigo
    public float stopDistance = 1.5f; // Distância para parar
    public float resumeFollowDistance = 1.8f; // Distância para retomar a perseguição
    private bool isFollowing = true;

    void Update()
    {
        // Verifica se a referência ao herói foi atribuída
        if (hero != null)
        {
            // Calcula a distância ao herói
            float distance = Vector3.Distance(transform.position, hero.position);

            if (isFollowing)
            {
                // Verifica se está perto o suficiente para parar
                if (distance > stopDistance)
                {
                    transform.LookAt(hero.position);
                    transform.Rotate(new Vector3(0, -90, 0), Space.Self); 

                    // Calcula a direção do herói
                    Vector3 direction = (hero.position - transform.position).normalized;

                    // Move o inimigo na direção do herói
                    transform.position += direction * speed * Time.deltaTime;
                }
                else
                {
                    // Está dentro da distância de parada
                    isFollowing = false;
                }
            }
            else
            {
                // Verifica se a distância aumentou para retomar a perseguição
                if (distance > resumeFollowDistance)
                {
                    isFollowing = true;
                }
            }
        }
    }
}