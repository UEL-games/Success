using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Movement Variables ------------------------
    [Header("Movement Variables")]
    //Controls Player Speed
    public float Mspeed = 5f;
    //Stores Targets Position
    public Vector3 targetPosition;
    //If true move
    private bool isMoving;

    //Animator
    private Animator PC_Animator;

    // Use this for initialization
    void Start ()
    {
        targetPosition = transform.position;
        isMoving = false;
        PC_Animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if left click pressed settarget position to where was clicked
        if (Input.GetMouseButton(0))
            SetTargetPosition();
        //if ismoving = true run moveplayer script
        if (isMoving)
            MovePlayer();

        Animate();
    }

    void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            targetPosition = hit.point;
            isMoving = true;
        }

    }

    void MovePlayer()
    {
        Vector3 targetPosition2 = new Vector3(targetPosition.x,
                                              this.transform.position.y,
                                              targetPosition.z);
        transform.LookAt(targetPosition2);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition2, Mspeed * Time.deltaTime);

        if (transform.position == targetPosition2)
        {
            isMoving = false;
        }
    }

    void Animate()
    {
        if (isMoving == true)
        {
            PC_Animator.SetBool("Walking", true);
        }
        else
        {
            PC_Animator.SetBool("Walking", false);
        }
    }

}
