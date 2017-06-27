using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAMovement : CubeMovement {
    float minWait = .5f;
    float maxWait = 3f;
    float timeCounter = 0f;
    float xDir=0;
    float yDir=0;
    int move;
    protected override void Start()
    {
        base.Start();
        move = Random.Range(0, 2);
        RoutineSimple();
    }

    // Update is called once per frame
    protected override void Update () {
        IAcounter();
        MoveCharacter(xDir, yDir);
        //myRig.velocity = Vector3.zero;
	}

    void IAcounter() {
        timeCounter -= Time.deltaTime;
        if (timeCounter <= 0) RoutineSimple();
    }
    void RoutineSimple() {
        move = 1 - move;
        timeCounter = Random.Range(minWait, maxWait);
        if (move == 1)
        {
            xDir = Random.Range(-1f, 1f);
            yDir = Random.Range(-1f, 1f);
        }
        else if (move == 0) {
            xDir = 0;
            yDir = 0;
        }
    }

}
