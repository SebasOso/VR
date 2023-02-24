using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class RotateGizmo : MonoBehaviour
{
    [SerializeField] private Vector3 rotation = new Vector3(0f, 0f, 0f);
    [SerializeField] private Vector3 aceleration = new Vector3(0f, .001f, 0f);
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        rotation += aceleration;
        gameObject.transform.Rotate(rotation);
    }
}
