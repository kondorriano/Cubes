using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineHandler : MonoBehaviour {

    class Limb
    {
        public LineRenderer line;
        public Transform[] positions = new Transform[4];
        public Vector3[] poses = new Vector3[4];

        public void setLinePositions()
        {
            for(int i = 0; i < poses.Length; ++i)
            {
                poses[i] = positions[i].position;
            }
            line.SetPositions(poses);
        }
    }

    public Material lineMat;

    Limb[] limbs;

	// Use this for initialization
	void Start () {
        limbs = new Limb[transform.childCount];
        for(int i = 0; i < transform.childCount; ++i)
        {
            Limb limb = new Limb();
            Transform child = transform.GetChild(i);            
            limb.line = child.gameObject.AddComponent<LineRenderer>();
            limb.line.material = lineMat;
            limb.line.startWidth = .1f;
            limb.line.endWidth = .1f;

            limb.line.numPositions = 4;
            limb.positions[0] = transform;
            limb.positions[1] = child;
            limb.positions[2] = child.GetChild(0);
            limb.positions[3] = child.GetChild(0).GetChild(0);
            limb.setLinePositions();
            limbs[i] = limb;
        }
	}
	
	// Update is called once per frame
	void LateUpdate () {
		for(int i = 0; i < limbs.Length; ++i)
        {
            limbs[i].setLinePositions();
        }
	}
}
