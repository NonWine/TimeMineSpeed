using UnityEngine;

public class CharacterContoll : MonoBehaviour
{
    
    CharacterController player;
    float xMove, zMove;
    Vector3 MoveDirection;
    public float speed = 7,jumpspeed = 0f, gravity = 0f;
    private void Start()
    {
        player = GetComponent<CharacterController>();
    }
    private void Update()
    {
        GetInput();
        
    }
    //our player is moving
    private void GetInput()
    {
       //moving
        if (player.isGrounded)
        {
            xMove = Input.GetAxis("Horizontal");
            zMove = Input.GetAxis("Vertical");
            MoveDirection = new Vector3(xMove, 0f, zMove);
            //for right direction
            MoveDirection = transform.TransformDirection(MoveDirection);
            MoveDirection *= speed;
        }
        //jump
        if(Input.GetKey(KeyCode.Space)&& player.isGrounded)
        {
            MoveDirection.y = jumpspeed;
        }
         MoveDirection.y -= gravity * Time.deltaTime;
        player.Move(MoveDirection*Time.deltaTime);
    }
}