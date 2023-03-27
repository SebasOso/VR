using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBook : MonoBehaviour
{
    public GameObject bookCover;
    public HingeJoint joint;
    // Start is called before the first frame update
    void Start()
    {
        joint = bookCover.GetComponent<HingeJoint>();
        joint.useMotor = false;
    }

    public void Open()
    {
        joint.useMotor = true;
    }
}
