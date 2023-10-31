using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private CharacterController controller;
    private Vector3 direction;

    void Update()
    {
        float moveForward = Input.GetAxis("Horizontal");
        float moveSideways = Input.GetAxis("Vertical");
        direction = new Vector3(moveForward, -1f, moveSideways).normalized;

        if (direction.magnitude >= 0.1f) 
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
        }
    }
}
