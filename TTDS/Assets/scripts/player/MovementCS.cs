using UnityEngine;

public class MovementCS : MonoBehaviour {

    [Range(2f, 10f)] public float MoveSpeed = 3;
    [Range(5f, 20f)]public float RotSpeed = 10;
    private Vector3 move;
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
        move = new Vector3(Input.GetAxis("h"), 0, Input.GetAxis("v"));       
            rbd.velocity = move * Time.fixedDeltaTime * MoveSpeed;
        
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Slerp(
            transform.rotation, Quaternion.LookRotation(new Vector3(MousePointerController.MPCinst.transform.position.x - transform.position.x, 0, MousePointerController.MPCinst.transform.position.z - transform.position.z)),
            RotSpeed * Time.fixedDeltaTime
            );
    }
}
