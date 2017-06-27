using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour {

    protected Rigidbody myRig;
    public float speed = 5f;

    //Knives thingy
    protected Transform myKnife = null;
   
    // Use this for initialization
    protected virtual void Start () {
        myRig = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	protected virtual void Update () {
		
	}

    protected void MoveCharacter(float yVel, float xVel)
    {
        Vector2 dir = new Vector2(xVel, yVel);
        dir.Normalize();
        myRig.velocity = speed * (Vector3.forward * dir.y + Vector3.right * dir.x);
        if (myRig.velocity.magnitude < 0.2) return;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(myRig.velocity.normalized), 0.4f);
    }

    public bool HasKnife()
    {
        return myKnife != null;
    }

    public Transform SwapKnives(Transform otherKnife)
    {
        Transform knife = myKnife;
        myKnife = otherKnife;
        if (myKnife != null)
        {
            myKnife.SetParent(transform);
            myKnife.localPosition = Vector3.up;
        }
        //set real knife position
        return knife;
    }
}

