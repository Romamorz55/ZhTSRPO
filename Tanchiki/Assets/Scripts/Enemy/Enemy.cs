using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy: MonoBehaviour
{
    public float visionRadius = 90f; // Радиус обзора бота
    public float visionAngle = 90f; // Угол обзора бота
    public float chaseDistance = 5f; // Дистанция для начала преследования игрока
    public Transform player; // Ссылка на игрока

    private NavMeshAgent agent;
    private LineRenderer lineRenderer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(ScanForPlayer());

        // Добавляем компонент LineRenderer для визуализации зоны видимости
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        lineRenderer.useWorldSpace = false;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material = new Material(Shader.Find("Standard"));
        lineRenderer.material.color = Color.red;
    }

    IEnumerator ScanForPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            CheckForPlayer();
        }
    }

    void CheckForPlayer()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, visionRadius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Tank_Player"))
            {
                Vector3 directionToPlayer = (hitCollider.transform.position - transform.position).normalized;
                float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

                if (angleToPlayer < visionAngle * 0.5f)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, directionToPlayer, out hit, chaseDistance))
                    {
                        if (hit.collider.CompareTag("Tank_Player"))
                        {
                            // Игрок замечен, начать преследование
                            ChasePlayer(hitCollider.transform.position);

                            // Обновляем визуализацию зоны видимости
                            //UpdateVisionCone(angleToPlayer);
                            return;
                        }
                    }
                }
            }
        }

        // Если игрок не виден, убираем визуализацию
        //lineRenderer.positionCount = 0;
    }

    void ChasePlayer(Vector3 playerPosition)
    {
        agent.SetDestination(playerPosition);
        // Дополнительные действия, если бот преследует игрока
    }

    void UpdateVisionCone(float angleToPlayer)
    {
        // Рассчитываем позиции точек для отображения конуса зоны видимости
        int segments = 20;
        lineRenderer.positionCount = segments + 1;
        float angle = -visionAngle * 0.5f;

        for (int i = 0; i < segments + 1; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * visionRadius;
            float z = Mathf.Cos(Mathf.Deg2Rad * angle) * visionRadius;

            lineRenderer.SetPosition(i, new Vector3(x, 0f, z));

            angle += visionAngle / segments;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        // Визуализация области зрения
        Gizmos.DrawWireSphere(transform.position, visionRadius);

        // Визуализация направления обзора
        Vector3 viewAngleA = DirFromAngle(-visionAngle * 0.5f, false);
        Vector3 viewAngleB = DirFromAngle(visionAngle * 0.5f, false);

        Gizmos.DrawLine(transform.position, transform.position + viewAngleA * visionRadius);
        Gizmos.DrawLine(transform.position, transform.position + viewAngleB * visionRadius);
    }

    Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
            angleInDegrees += transform.eulerAngles.y;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
