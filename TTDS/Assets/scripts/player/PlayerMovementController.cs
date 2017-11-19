using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

    [Range(2f, 10f)] public float MoveSpeed = 3;
    [Range(5f, 20f)]public float RotSpeed = 10;
    private Vector3 MoveV;
    private Rigidbody rbd;

	void Awake () {
        rbd = GetComponent<Rigidbody>();
        MoveSpeed *= 100;
	}
	
	
	void FixedUpdate ()
    {
        Move();
        Rotate();
	}

    private void Move()
    {
        MoveV = new Vector3(Input.GetAxis("h"), 0, Input.GetAxis("v"));       
            rbd.velocity = MoveV * Time.fixedDeltaTime * MoveSpeed;
        
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Slerp(
            transform.rotation, Quaternion.LookRotation(new Vector3(MousePointerController.MPCinst.transform.position.x - transform.position.x, 0, MousePointerController.MPCinst.transform.position.z - transform.position.z)),
            RotSpeed * Time.fixedDeltaTime
            );
    }
}
