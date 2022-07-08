using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] Transform targetTrasform;
    [SerializeField] Cubeton cubetonPrefab;
    [SerializeField] float groundPaddingToSpawn = 0.5f;
    [SerializeField] float spawnRadius = 10f;
    
    Vector2 inputMovement;
    Vector3 rawInputMovement;
    Mover mover;
    ObjectPool<Cubeton> pool;

    private void Start()
    {
        SetupObjectPooler();
    }

    private void SetupObjectPooler()
    {
        pool = new ObjectPool<Cubeton>
        (
            createFunc: () => Instantiate(cubetonPrefab),
            actionOnGet: (cubeton) => cubeton.gameObject.SetActive(true),
            actionOnRelease: (cubeton) => cubeton.gameObject.SetActive(false),
            actionOnDestroy: (cubeton) => Destroy(cubeton.gameObject),
            collectionCheck: false,
            defaultCapacity: 10,
            maxSize: 100
        );
    }

    private void Awake() 
    {
        mover = GetComponent<Mover>();
    }
    
    void FixedUpdate()
    {
        UpdatePlayerMovement();
        FaceTarget();
    }

    void OnMove(InputValue value)
    {
        inputMovement = value.Get<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0f, inputMovement.y);
    }

    void OnFire(InputValue value)
    {
        Cubeton cubeTon = pool.Get();
        SetupCubetonPosition(cubeTon);
    }

    private void SetupCubetonPosition(Cubeton cubeTon)
    {
        cubeTon.transform.position = transform.position + Random.insideUnitSphere * spawnRadius;
        cubetonPrefab.transform.rotation = Quaternion.identity;
        Vector3 clampedPosition = new Vector3(cubeTon.transform.position.x, groundPaddingToSpawn, cubeTon.transform.position.z);
        cubeTon.transform.position = clampedPosition;
    }

    void UpdatePlayerMovement()
    {
        mover.UpdateMovementData(rawInputMovement);
    }

    private Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    private void FaceTarget()
    {
        Vector3 direction = (targetTrasform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.fixedDeltaTime * turnSpeed);
    }
}
