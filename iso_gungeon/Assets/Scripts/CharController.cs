using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 4f;
    Vector3 forward, right, movement;
    float camRayLength = 100f;
    int floorMask;
    Rigidbody playerRigidbody;
    Quaternion newRotation;
    void Start()
    {
        floorMask = LayerMask.GetMask("Floor");
        playerRigidbody = GetComponent<Rigidbody>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.anyKey)
            Move();
        turning();
    }

    void Move()
    {
        // if (Input.GetKeyDown(KeyCode.LeftShift))
        //     StartCoroutine(PlayerDash());
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        transform.position += rightMovement;
        transform.position += upMovement;
    }

    IEnumerator PlayerDash()
    {
        moveSpeed += 20;
        yield return new WaitForSeconds(1);
        moveSpeed -= 20;
    }

    void turning ()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation (newRotation);
        }
    }

    public Quaternion GetRotation()
    {
        return (newRotation);
    }
}
