using UnityEngine;

public class KartController : MonoBehaviour
{
    public float speed = 50f;
    public float turnSpeed = 100f;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints |= RigidbodyConstraints.FreezePositionY;
        rb.constraints |= RigidbodyConstraints.FreezeRotationX;
        rb.constraints |= RigidbodyConstraints.FreezeRotationZ;
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");

        Vector3 forward = -transform.forward;
        forward.y = 0f;
        forward.Normalize();

        rb.MovePosition(
    rb.position + forward * move * speed * 5f * Time.fixedDeltaTime
);

        if (Mathf.Abs(move) > 0.01f)
        {
            Quaternion rotation = Quaternion.Euler(
                0f,
                turn * turnSpeed * Mathf.Sign(move) * Time.fixedDeltaTime,
                0f
            );

            rb.MoveRotation(rb.rotation * rotation);
        }
    }
}