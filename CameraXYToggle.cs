using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

namespace ActionRPGController
{
    [RequireComponent(typeof(CinemachineInputProvider))]
    public class CameraXYToggle : MonoBehaviour
    {
        [HideInInspector]
        public CinemachineInputProvider Provider;

        [SerializeField]
        public InputActionReference XYTargetAction;

        [SerializeField]
        public InputActionReference CameraMoveToggle;
        private InputAction CameraMoveToggleAction;

        private void OnEnable()
        {
            Provider = GetComponent<CinemachineInputProvider>();

            if (CameraMoveToggle != null)
            {
                CameraMoveToggleAction = CameraMoveToggle.ToInputAction();
                CameraMoveToggleAction.started += EnableCameraMovement;
                CameraMoveToggleAction.canceled += DisableCameraMovement;
                CameraMoveToggleAction.Enable();
            }
        }

        private void OnDisable()
        {
            if (CameraMoveToggleAction != null)
            {
                CameraMoveToggleAction.Disable();
                CameraMoveToggleAction = null;
            }
        }

        private void EnableCameraMovement(InputAction.CallbackContext ctx)
        {
            if(Provider != null)
            {
                Provider.XYAxis = XYTargetAction;
            }
        }

        private void DisableCameraMovement(InputAction.CallbackContext ctx)
        {
            if(Provider != null)
            {
                Provider.XYAxis = null;
            }
        }
    }
}
