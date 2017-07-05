using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour {

    protected Rigidbody myRig;
    protected Animator myAnim;
    public float speed = 5f;

    float idleCounter = 0;
    float idleTime = .5f;
    bool staying = true;

    //Knives thingy
    protected Transform myKnife = null;

    //Faces
    public Renderer faceRend;
    //Hand
    public Transform hand;
   
    // Use this for initialization
    protected virtual void Start () {
        myRig = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	protected virtual void Update () {
        
	}

    protected virtual void LateUpdate()
    {
        float velocity = myRig.velocity.magnitude;
        myAnim.SetFloat("Speed", velocity);
        if (velocity == 0)
        {
            idleCounter -= Time.deltaTime;
            if (!staying && idleCounter <= 0)
            {
                staying = true;
                myAnim.SetTrigger("Staying");
            }
        }
        else
        {
            idleCounter = idleTime;
            staying = false;
        }
    }

    protected void MoveCharacter(float yVel, float xVel, float speedValue)
    {
        Vector2 dir = new Vector2(xVel, yVel);
        dir.Normalize();
        myRig.velocity = speed * speedValue * (Vector3.forward * dir.y + Vector3.right * dir.x);
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
        if (myKnife != null) SetKnifePosition();

        return knife;
    }

    protected void SetKnifePosition()
    {
        myKnife.SetParent(hand);
        myKnife.localPosition = Vector3.zero;
    }

    public virtual void SetCoolFace(Texture tex)
    {
        faceRend.material.mainTexture = tex;
    }
}

