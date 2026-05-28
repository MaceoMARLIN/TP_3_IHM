using UnityEngine;

public class TargetCompass : MonoBehaviour
{
    public Transform player;
    public RectTransform arrowUI;
    public Material vert_hit;

    private GameObject[] targets;

    private Transform currentTarget;

    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Cible");

        SelectNewTarget();
    }

    void Update()
    {
        // Si plus de cible
        if (currentTarget == null)
            return;

        // Direction
        Vector3 direction =
            currentTarget.position - player.position;

        direction.y = 0f;

        float angle =
            Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        arrowUI.rotation =
            Quaternion.Euler(0, 0, -angle + player.eulerAngles.y);

        // Vérifie si touchée
        bool state = currentTarget.GetComponent<MeshRenderer>().sharedMaterial == vert_hit;

        if (state == true)
        {
            SelectNewTarget();
        }
    }

    void SelectNewTarget()
    {
        float minDistance = Mathf.Infinity;

        currentTarget = null;

        foreach (GameObject target in targets)
        {
            bool state = target.GetComponent<MeshRenderer>().sharedMaterial == vert_hit;

            // Ignore touchées
            if (state == true)
                continue;

            float distance =
                Vector3.Distance(
                    player.position,
                    target.transform.position
                );

            if (distance < minDistance)
            {
                minDistance = distance;
                currentTarget = target.transform;
            }
        }
    }
}
