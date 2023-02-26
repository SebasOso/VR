using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class RotateGizmo : MonoBehaviour
{
    [SerializeField] private Vector3 scale = new Vector3(.001f, .001f, .001f);
    [SerializeField] private Vector3 limitScale = new Vector3(0.5f, 0.5f, 0.5f);
    [SerializeField] private Vector3 limitScaleUp = new Vector3(1f, 1f, 1f);
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0f,3f,0f, Space.World);
        Scale();
    }
    private void Scale()
    {
        if (transform.localScale.x >=0.5)
        {
            transform.localScale -= scale;
        }
        else
        {
            transform.localScale += scale;
        }
       
    }
}
