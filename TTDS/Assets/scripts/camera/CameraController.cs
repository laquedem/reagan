using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{

    #region old
    /*
    #region v1
    private Vector3 aim;
    public Transform[] targs;
    public Vector3 offset;
    private Vector3 m_MoveVelocity;
    private float m_ZoomVelocity;
    public float moveTime;
    public float zoomTime;
    public float min_Size;
    public float max_Size;
    public float edgeBuffer;

    private float sx, sz;
    
	void Awake () {
        aim = Vector3.zero;
	}
	
	void FixedUpdate () {
        Move();

        Zoom();
	}

    private void Move()
    {
        CalcAimPos();
        MoveCamera();
    }

    private void CalcAimPos()
    {
        for (int i = 0; i < targs.Length; i++)
        {
            aim = (aim + targs[i].position) / 2;
        }
        aim.Set(aim.x, 0, aim.z);
        aim += offset;
    }

    private void MoveCamera()
    {
        // transform.position = Vector3.Lerp(transform.position, aim + offset, Time.fixedDeltaTime * CamV);
        transform.position = Vector3.SmoothDamp(transform.position, aim, ref m_MoveVelocity, moveTime);
    }

    private void Zoom()
    {
        Camera.main.orthographicSize = Mathf.SmoothDamp(Camera.main.orthographicSize, TargSize(), ref m_ZoomVelocity, zoomTime);
    }

    private float TargSize()
    {
        Vector3 localAim = transform.InverseTransformPoint(aim);

        float size = 0f;

        for (int i = 0; i < targs.Length; i++)
        {
            Vector3 targLocPos = transform.InverseTransformPoint(targs[i].position);

            Vector3 aimPosToTarg = targLocPos - localAim;

            size = Mathf.Max(size, Mathf.Abs(aimPosToTarg.y));

            size = Mathf.Max(size, Mathf.Abs(aimPosToTarg.x) / Camera.main.aspect);
        }

        size = Mathf.Clamp(size, min_Size, max_Size);

        size += edgeBuffer;

        return size;
    }

    #endregion
    */

    /* 
    #region easy

    private Vector3 targ;
    public Transform[] targs = new Transform[2];
    public Transform player;
    public Vector3 offset;
    private Vector3 MoveVelocity;
    public float Distance;
    public float moveSpeed;
    public float maxMoveSpeed;
    public GameObject average;

    private void FixedUpdate()
    {

        targ = Vector3.zero;

        for (int i = 0; i < targs.Length; i++)
        {
            targ += targs[i].position / 2;
        }

        if (Vector3.Distance(MousePointerController.MPCinst.transform.position, player.position) > Distance)
            targ = MousePointerController.MPCinst.transform.position * Distance / Vector3.Distance(MousePointerController.MPCinst.transform.position, player.position);

        average.transform.position = targ;

        transform.position = Vector3.SmoothDamp(transform.position, targ + offset, ref MoveVelocity, moveSpeed, maxMoveSpeed);
    }

    #endregion
    */

    /*
#region v3
public Transform player;
private Vector3 averagePos;
public GameObject example;
private Vector3 currentVelocity;
public Vector3 offset;
public float smoothTime;
public float maxSpeed;
public float maxViewDistance;  // setter will be a good idea


private void FixedUpdate()
{
    // making y-less positions for player and mpc
    Vector3 yPlayer = player.position - new Vector3(0, player.position.y, 0);
    Vector3 yMPC = MousePointerController.MPCinst.transform.position - new Vector3(0, MousePointerController.MPCinst.transform.position.y, 0);

    // Debug.Log(yPlayer);
    // Debug.Log(yMPC);

    // counting average position of player and aim
    averagePos = (yPlayer + yMPC) / 2;

    // limiting maximum distance of average position from the player
    if (Vector3.Distance(yPlayer, averagePos) > maxViewDistance)
    {
        Debug.Log(averagePos);
        averagePos *= maxViewDistance / Vector3.Distance(yPlayer, averagePos);
        Debug.Log(averagePos);
    }

    example.transform.position = averagePos;    // just for viewing average position

    // Debug.Log(Vector3.Distance(yPlayer, yMPC));
    // Debug.Log(Vector3.Distance(yPlayer, averagePos));

    transform.position = Vector3.SmoothDamp(transform.position, averagePos + offset, ref currentVelocity, smoothTime, maxSpeed);
}

#endregion
*/
#endregion


    public Transform targ;
    public Vector3 offset = new Vector3(0, 10, -10f * (float) Math.Tan(20 * Math.PI / 180));
    private Vector3 currentVelocity;
    public float smoothTime;

    private void FixedUpdate()
    {
        targ.position.Set(targ.position.x, 0, targ.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, targ.position + offset, ref currentVelocity, smoothTime);

        // transform.LookAt(targ);
    }
}
