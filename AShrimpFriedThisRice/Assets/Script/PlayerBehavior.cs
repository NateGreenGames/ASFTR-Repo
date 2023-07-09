using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBehavior : MonoBehaviour
{
    public GameObject carriedObject;
    public GameObject whatImLookingAt;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float maxInteractDistance;
    [SerializeField] private Transform carriedObjectAnchor;
    [SerializeField] private ParticleSystem m_Part;
    private GameObject currentlyCarriedObjectRef;

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
        if(moveDirection == Vector3.zero)
        {
            m_Part.Stop();
        }
        else
        {
            m_Part.Play();
        }
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
        interactedThisFrame = Input.GetKeyDown(KeyCode.E);
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

        Collider[] testColliderArray = Physics.OverlapSphere(carriedObjectAnchor.position, maxInteractDistance);

        float closestDistance = Mathf.Infinity;
        int indexOfClosestPoint = 100;
        for (int i = 0; i < testColliderArray.Length; i++)
        {
            //find closest colider that isn't the player.
            float distanceToThisPoint = (transform.position - testColliderArray[i].transform.position).magnitude;
            if (distanceToThisPoint < closestDistance && testColliderArray[i].name != "Player")
            {
                closestDistance = distanceToThisPoint;
                indexOfClosestPoint = i;
            }
        }
        if (indexOfClosestPoint != 100 && testColliderArray[indexOfClosestPoint].gameObject.TryGetComponent<IInteractable>(out IInteractable interactionReference) && interactionReference.isInteractable == true)
        {
            whatImLookingAt = testColliderArray[indexOfClosestPoint].gameObject;
            interactionReference.OnHover();
            if (interactedThisFrame) interactionReference.OnInteract();
        }
        else
        {
            whatImLookingAt = null;
        }



        /*
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, maxInteractDistance))
        {
            whatImLookingAt = hitInfo.collider.gameObject;
            if (whatImLookingAt.TryGetComponent<IInteractable>(out IInteractable interactionReference) && interactionReference.isInteractable == true)
            {
                interactionReference.OnHover();
                if (interactedThisFrame) interactionReference.OnInteract();
                //UpdatePlayerCarriedObject();
            }
        }
        else
        {
            whatImLookingAt = null;
        }*/
    }

    public void UpdatePlayerCarriedObject(GameObject _itemToChangeTo)
    {
        carriedObject = _itemToChangeTo;
        if(carriedObject != null)
        {
            carriedObject.transform.parent = carriedObjectAnchor;
            carriedObject.transform.position = carriedObjectAnchor.position;
        }
    }

    public void SpawnNewPlayerCarriedObject(ItemSO _itemToChangeTo)
    {
        carriedObject = Instantiate(Resources.Load("prefabs/ingredienttestobject") as GameObject, carriedObjectAnchor);
        carriedObject.GetComponent<FoodInstance>().ingredientsPresent.Add(_itemToChangeTo);
    }
}
