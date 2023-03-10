using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    public XRController leftTeleportRay;
    public XRController rightTeleportRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;

    public bool EnableLeftTeleport { get; set; } = true;
    public bool EnableRightTeleport { get; set; } = true;


    void Update()
    {
        if (leftTeleportRay)
        {
            leftTeleportRay.gameObject.SetActive(EnableLeftTeleport && CheackIfActivated(leftTeleportRay));
        }
        if (rightTeleportRay)
        {
            rightTeleportRay.gameObject.SetActive(EnableRightTeleport && CheackIfActivated(rightTeleportRay));
        }
    }

    public bool CheackIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }
}
