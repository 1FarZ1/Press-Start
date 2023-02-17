using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    [HideInInspector]public CharacterController playerCharacter;

    [Header("Movements Settings")]
    public float MoveSpeed;
    public float CrouchSpeed;
    public float JumpForce;
    private float Velocity;
    [HideInInspector]public Vector3 AddedVelocity;
    [Header("Crouch Settings")]
    public float CrouchHeight;
    private Vector3 Direction;
    public string CurrentItem;

    public float CounterScore;
    
    [Header("PickUp Settings")]
    public GameObject HandPickUp;

    [Header("RespawnSettings")]
    public int YRespawn = -100;
    public Island CurrentIsland;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerCharacter = GetComponent<CharacterController>();
        // AudioManager.Instance.PlaySFX("gameStart");
    }
    private void Update()
    {
        PlayerMovements();
    }
    private void LateUpdate()
    {
        if (transform.position.y < YRespawn)
        {
            // AudioManager.Instance.PlaySFX("gameOver");
            transform.SetPositionAndRotation(CurrentIsland.IslandSpawnPoint.position, CurrentIsland.IslandSpawnPoint.rotation);
            CameraController.Instance.xRotation = 0;
        }
    }

    private void PlayerMovements()
    {
        Direction = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical") + Vector3.up * Velocity;

        if (!playerCharacter.isGrounded)
        {
            Velocity -= Time.deltaTime * 9.8f;
           
        }
        else
        {
            AddedVelocity = Vector3.zero;
            Velocity = -0.5f;
        }

        if (Input.GetKey(KeyCode.Space) && playerCharacter.isGrounded)
            Velocity = JumpForce;

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            transform.localScale = new Vector3(1, 1, 1);
            Direction *= MoveSpeed;
        }
        else
        {
            transform.localScale = new Vector3(1, CrouchHeight, 1);
            Direction *= CrouchSpeed;
        }

        Direction.y = Velocity;

        playerCharacter.Move((Direction + AddedVelocity) * Time.deltaTime);
    }
}
