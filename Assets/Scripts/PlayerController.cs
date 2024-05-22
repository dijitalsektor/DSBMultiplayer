using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField]
    private float walkSpeed = 0.02f;

    [SerializeField]
    private Vector2 defaultSpawnPointRange = new Vector2(-4, 4);


    [SerializeField]
    private NetworkVariable<float> forwardBackPosition = new NetworkVariable<float>();

    [SerializeField]
    private NetworkVariable<float> leftRightPosition = new NetworkVariable<float>();

    // client caching
    private float oldForwardBackPosition;
    private float oldLeftRightPosition;


    private void Start()
    {
        if (IsClient && IsOwner)
        {
         
            transform.position = new Vector3(
                                            Random.Range(defaultSpawnPointRange.x, defaultSpawnPointRange.y),
                                            0,
                                            Random.Range(defaultSpawnPointRange.x, defaultSpawnPointRange.y));

        }

    }

    private void Update()
    {
        if (IsServer)
        {
            UpdateServer();
        }

        if (IsClient && IsOwner)
        {
            UpdateClient();
        }
    }

    private void UpdateServer()
    {

    }

    private void UpdateClient()
    {

        float forwardBackward = 0;
        float leftRight = 0;

        //getInput
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            forwardBackward += walkSpeed;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            forwardBackward -= walkSpeed;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            leftRight -= walkSpeed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            leftRight += walkSpeed;
        }

        if (oldForwardBackPosition != forwardBackward || oldLeftRightPosition != leftRight)
        {
            oldForwardBackPosition = forwardBackward;
            oldLeftRightPosition = leftRight;

            Debug.Log($" oldForwardBackPosition :  {oldForwardBackPosition} ,  oldLeftRightPosition:  {oldLeftRightPosition}");
            //update the server
            //UpdateClientPositionServerRpc(forwardBackward, leftRight);
        }


    }






}
