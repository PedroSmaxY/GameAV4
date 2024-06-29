using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyFollow : MonoBehaviour
{
    public Transform hero;  // Refer�ncia ao her�i
    public float speed = 1.5f; // Velocidade do inimigo
    public float stopDistance = 1.5f; // Dist�ncia para parar
    public float resumeFollowDistance = 1.8f; // Dist�ncia para retomar a persegui��o
    private bool isFollowing = true;

    void Update()
    {
        // Verifica se a refer�ncia ao her�i foi atribu�da
        if (hero != null)
        {
            // Calcula a dist�ncia ao her�i
            float distance = Vector3.Distance(transform.position, hero.position);

            if (isFollowing)
            {
                // Verifica se est� perto o suficiente para parar
                if (distance > stopDistance)
                {
                    transform.LookAt(hero.position);
                    transform.Rotate(new Vector3(0, -90, 0), Space.Self); 

                    // Calcula a dire��o do her�i
                    Vector3 direction = (hero.position - transform.position).normalized;

                    // Move o inimigo na dire��o do her�i
                    transform.position += direction * speed * Time.deltaTime;
                }
                else
                {
                    // Est� dentro da dist�ncia de parada
                    isFollowing = false;
                }
            }
            else
            {
                // Verifica se a dist�ncia aumentou para retomar a persegui��o
                if (distance > resumeFollowDistance)
                {
                    isFollowing = true;
                }
            }
        }
    }
}