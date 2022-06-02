
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public PlayerMovementSO playerMovementSO;

    [SerializeField] private float limit_X;
    public Vector3 offSet;

    public Rigidbody rb;

    Camera cam;


    private void Start()
    {
        cam = Camera.main; 
    }

    private void FixedUpdate()
    {
        if (!LevelManager.instance.gameFlow)
            return;

        float newX = 0;
        float touchXDelta = 0;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // touch input
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            // mouse input
            touchXDelta = Input.GetAxis("Mouse X");
        }
        newX = transform.position.x + playerMovementSO.xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limit_X, limit_X); // constrains

        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + playerMovementSO._currentRunningSpeed * Time.deltaTime);
        
        rb.MovePosition(newPosition); 

    }
    private void Update()
    {
        cam.transform.position = transform.position + offSet;
    }
 

}
