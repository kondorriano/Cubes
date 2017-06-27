using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CubeMovement{
   
    Transform touchedKnife = null;
    Transform touchedCube = null;
  
    // Update is called once per frame
    protected override void Update () {
        float yVel = Input.GetAxis("Vertical");
        float xVel = Input.GetAxis("Horizontal");
        MoveCharacter(yVel, xVel);
        KnifeStuff();
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

            myKnife.SetParent(transform);
            myKnife.localPosition = Vector3.up;
            //set real knife position
            
        }
        else if (touchedCube != null)
        {
            CubeMovement mov = touchedCube.GetComponent<CubeMovement>();
            if (myKnife != null || mov.HasKnife())
            {
                myKnife = mov.SwapKnives(myKnife);
                if (myKnife != null)
                {
                    myKnife.SetParent(transform);
                    myKnife.localPosition = Vector3.up;
                }
                //set real knife position
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
