using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CubeMovement{
   
    Transform touchedKnife = null;
    Transform touchedCube = null;

    public Texture coolFace;
    public Texture angryFace;

    bool running = false;
  
    // Update is called once per frame
    protected override void Update () {
        float yVel = Input.GetAxis("Vertical");
        float xVel = Input.GetAxis("Horizontal");
        float speedValue = (Input.GetKey(KeyCode.X)) ? 2 : 1;
        MoveCharacter(yVel, xVel, speedValue);
        KnifeStuff();

        if(myRig.velocity.magnitude > speed*1.1f && !running)
        {
            running = true;
            SetFace(angryFace);
        } else if(myRig.velocity.magnitude <= speed && running)
        {
            running = false;
            SetFace(coolFace);
        }
    }

    public override void SetCoolFace(Texture tex)
    {
        coolFace = tex;
        base.SetCoolFace(tex);
    }

    void SetFace(Texture tex)
    {
        faceRend.material.mainTexture = tex;
    }

    public void SetAngryFace(Texture tex)
    {
        angryFace = tex;
    }

    void KnifeStuff()
    {
        bool swap = Input.GetKeyDown(KeyCode.Z);
        if (!swap) return;
        if (touchedKnife != null && myKnife == null)
        {
            KnifeScript kniS = touchedKnife.GetComponent<KnifeScript>();
            if (!kniS.onGround) return;
            kniS.onGround = false;
            Destroy(touchedKnife.GetComponent<Collider>());
            myKnife = touchedKnife;
            touchedKnife = null;

            SetKnifePosition();
            
        }
        else if (touchedCube != null)
        {
            CubeMovement mov = touchedCube.GetComponent<CubeMovement>();
            if (myKnife != null || mov.HasKnife())
            {
                myKnife = mov.SwapKnives(myKnife);
                if (myKnife != null) SetKnifePosition();
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "knife")
        {
            touchedKnife = other.transform;
        }
        else if (other.tag == "cube") {
            touchedCube = other.transform;
        }
            
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "knife" && other.transform == touchedKnife)
        {
            touchedKnife = null;
        }
        else if (other.tag == "cube" && other.transform == touchedCube)
        {
            touchedCube = null;
        }
    }
}
