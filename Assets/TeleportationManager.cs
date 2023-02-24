using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset _actionAsset;
    [SerializeField] private XRRayInteractor _rayInteractor;
    [SerializeField] private TeleportationProvider _teleportationProvider;
    [SerializeField] private GameObject _leftHand;
    private InputAction _thumbstick;
    private bool _isActive;
    private XRInteractorLineVisual _lineVisual;
    private bool _isTeleportable;

    // Start is called before the first frame update
    void Start()
    {
        _lineVisual = _leftHand.GetComponent<XRInteractorLineVisual>();
        _rayInteractor.enabled = false;
        var activate = _actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Activate");
        activate.Enable();
        activate.performed += OnTeleportActivate;
        var cancel = _actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Cancel");
        cancel.Enable();
        cancel.performed += OnTeleportCancel;
        _thumbstick = _actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Move");
        _thumbstick.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isActive)
        {
            return;
        }
        if (_thumbstick.triggered)
        {
            return;
        }
        if (!_rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            _rayInteractor.enabled = false;
            _isActive = false;
            return;
        }
        
        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = hit.point,
            //destinationRotation = 
            
        };

        if (!hit.collider.CompareTag("Teleportable"))
        {
            _rayInteractor.enabled = false;
            _isActive = false;
            return;
        }
        _teleportationProvider.QueueTeleportRequest(request);
        _rayInteractor.enabled = false;
        _isActive = false;
    }

    void OnTeleportActivate(InputAction.CallbackContext context)
    {
        _rayInteractor.enabled = true;
        _isActive = true;
    }
    void OnTeleportCancel(InputAction.CallbackContext context)
    {
        _rayInteractor.enabled = false;
        _isActive = false;
    }
}
