using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float range;
    private Vector3 start;

    private void Awake()
    {
        start = transform.position;
    }

    private void FixedUpdate()
    {
        while (Vector3.Distance(transform.position, start) < range)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, speed * Time.fixedDeltaTime))
            {
                Debug.Log("HIT " + hit.transform.name);
                Destroy(gameObject);
            }

            transform.position += transform.forward * Time.fixedDeltaTime * speed;

            return;
        }

        Destroy(gameObject);
    }
}
