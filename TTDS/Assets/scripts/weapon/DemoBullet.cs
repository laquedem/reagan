using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoBullet : MonoBehaviour
{
    public float speed;
    public float distance;
    private float covered = 0f;
    private Ray ray;
    private RaycastHit hit;
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (covered < distance) {
            ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out hit, speed * Time.fixedDeltaTime))
            {
                Debug.Log(hit.transform.name);
                Rigidbody rbd = hit.transform.GetComponent<Rigidbody>();

                if (rbd != null)
                {
                    Debug.Log("apll force");
                    rbd.AddForce(transform.forward * 500 * rbd.mass);
                }

                Destroy(gameObject);
            }
        } else Destroy(gameObject);

        transform.position += transform.forward * speed * Time.fixedDeltaTime;
	}
}
