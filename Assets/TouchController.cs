using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {
    private HingeJoint myHingeJoint;
    float defaultAngle = 20f;
    float flickAngle = -20f;
    int width = Screen.width;
	// Use this for initialization
	void Start () {
        this.myHingeJoint = GetComponent<HingeJoint>();
        SetAngle(this.defaultAngle);
		if(Input.touchSupported)
        {
           Debug .Log ("タッチに対応している");
        }
        else
        {
            Debug.Log("対応してない");
        }
	}

    // Update is called once per frame
    void Update() {
        if(Input.touchCount > 0)
        {
            foreach (Touch t in Input.touches)
            {
                if (t.phase == TouchPhase.Began  && tag == "RIghtFripperTag" && t.position.x >= Screen.width / 2)
                {
                    Debug.Log("押してる");
                    SetAngle(flickAngle);
                }
                else if (t.phase == TouchPhase.Began && tag == "LeftFripperTag" && t.position.x <= Screen.width / 2)
                {
                    Debug.Log("押してる");
                    SetAngle(flickAngle);
                }
                else if (t.phase == TouchPhase.Ended && tag == "RIghtFripperTag" && t.position.x >= Screen.width / 2)
                {
                    SetAngle(defaultAngle);
                }
                else if (t.phase == TouchPhase.Ended  && tag == "LeftFripperTag" && t.position.x <= Screen.width / 2)
                {
                    SetAngle(defaultAngle);
                }



            }
        }

       
	}
    public void SetAngle(float angle)
    {
        JointSpring j = this.myHingeJoint.spring;
        j.targetPosition = angle;
        this.myHingeJoint.spring = j;
    }
}
