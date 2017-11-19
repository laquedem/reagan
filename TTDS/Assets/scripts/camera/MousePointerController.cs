using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointerController : MonoBehaviour
{
    public static MousePointerController MPCinst;

    private Ray ray;
    private RaycastHit hit;
    public LayerMask mask;

    private void Awake()
    {
        if (MPCinst == null)
            MPCinst = this;
    }
    void FixedUpdate ()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f, mask))
        {
            transform.position = hit.point - new Vector3(0, hit.point.y, 0);
        }
	}
}
