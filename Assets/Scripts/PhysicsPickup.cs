using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPickup : MonoBehaviour
{

    private Rigidbody CurrentObject;

    [SerializeField] private LayerMask PickupMask;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private Transform PickupTarget;
    [Space]
    [SerializeField] private float PickupRange;
    [Space]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip PickUpAudio;
    [SerializeField] private AudioClip ErrorAudio;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CurrentObject)
            {
                CurrentObject.useGravity = true;
                CurrentObject = null;
                return;
            }

            Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
            {
                CurrentObject = HitInfo.rigidbody;
                CurrentObject.useGravity = false;
                CurrentObject.freezeRotation = true;
                audioSource.PlayOneShot(PickUpAudio);
            }
            else
            {
                audioSource.PlayOneShot(ErrorAudio);
            }
        }
    }

    private void FixedUpdate()
    {
        if (CurrentObject)
        {
            Vector3 DirectionToPoint = PickupTarget.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            CurrentObject.velocity = DirectionToPoint * 12f * DistanceToPoint;
        }
    }
}
