using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 6;
    [SerializeField]
    private float turningSpeed = 1;
    private new Rigidbody rigidbody;
    private Camera viewCamera;
    private Vector3 velocity;

    // Set up references
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        viewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
        transform.LookAt(mousePos + Vector3.up * transform.position.y);
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
    }

    // FixedUpdate is called in each physic engine steep
    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
