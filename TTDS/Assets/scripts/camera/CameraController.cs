using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{
    public float maxDist;
    public List<Transform> targs = new List<Transform>();
    private Vector3 targ;
    public Vector3 offset = new Vector3(0, 10, -10f * (float) Math.Tan(20 * Math.PI / 180));
    private Vector3 velocity;
    public float smoothTime;

    public void Awake()
    {
        targ = targs[0].position;
    }

    private void LateUpdate()
    {
        MultipleTargetBehaviour();
    }

    // newer version of camera behaviour

    private void MultipleTargetBehaviour()
    {
        MoveCam();
    }

    private void MoveCam()
    {
        targ= FindAveragePosition();

        targ.Set(targ.x, 0, targ.z);

        transform.position = Vector3.SmoothDamp(transform.position, targ + offset, ref velocity, smoothTime);
    }

    private Vector3 FindAveragePosition()
    {
        if (targs.Count == 1)
        {
            return targs[0].position;
        }

        var bound = new Bounds(targs[0].position, Vector3.zero);

        for (int i = 0; i < targs.Count; i++)
        {
            bound.Encapsulate(targs[i].position);
        }

        if (Vector3.Distance(bound.center, targs[0].position) > maxDist)
        {
            Vector3 delta = bound.center - targs[0].position;
            delta.Set(delta.x, 0, delta.z);
            delta *= maxDist / (Vector3.Distance(bound.center, targs[0].position));
            return targs[0].position + delta;
        }

        return bound.center;
    }

    public void AddTarget(Transform _targ)
    {
        targs.Add(_targ);
    }

    public void RemoveTarg(ref Transform _targ)
    {
        targs.Remove(_targ);
    }
}
