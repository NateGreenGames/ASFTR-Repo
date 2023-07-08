using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBehavior : MonoBehaviour
{
    public ItemSO carriedObject;
    public GameObject lookingAtTarget;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float maxInteractDistance;

    private Rigidbody m_RB;


    //Input Variables;
    private Vector3 moveDirection;
    private bool interactedThisFrame;

    private void Start()
    {
        m_RB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GatherInput();
        FaceTowardsMovement();

        Interact();

    }

    private void FixedUpdate()
    {
        m_RB.velocity = moveDirection.normalized * movementSpeed;
    }


    private void GatherInput()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        interactedThisFrame = Input.GetKeyDown(KeyCode.Space);
    }
    private void FaceTowardsMovement()
    {
        if(moveDirection != Vector3.zero)
        {
            transform.LookAt(transform.position + moveDirection);
        }
    }
    private void Interact()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, maxInteractDistance))
        {
            lookingAtTarget = hitInfo.collider.gameObject;
            if (lookingAtTarget.TryGetComponent<IInteractable>(out IInteractable interactionReference))
            {
                interactionReference.OnHover();
                if (interactedThisFrame) interactionReference.OnInteract();
            }
        }
        else
        {
            lookingAtTarget = null;
        }
    }
}
