using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float sprintSpeed = 10f;
    [SerializeField] private Camera mainCamera;
    private PlayerAnimation playerAnimation;
    private PlayerInput playerInput;
    private float rotationSpeed = 8f;

    void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        playerInput = GetComponent<PlayerInput>();
    }

    public void Move(Vector2 input)
    {
        // SprintStop 애니메이션 재생 중일 때는 이동하지 않음
        if (playerAnimation.SprintStop())
        {
            playerAnimation.SetMoving(0);
            return;
        }


        // 이동 속도 설정 (Sprint 상태에 따라 다르게 적용)
        float currentSpeed = playerInput.IsSprinting() ? sprintSpeed : moveSpeed;

        // 애니메이션 상태 설정
        if (input.sqrMagnitude > 0.01f)
        {
            playerAnimation.setStarting(true);
            playerAnimation.SetMoving(playerInput.GetMoveInput().sqrMagnitude);

            if (playerInput.IsSprinting() == true)
            {
                playerAnimation.SetSprinting(true);
            }
            else
            {
                playerAnimation.SetSprinting(false);
            }
        }
        else
        {
            playerAnimation.SetMoving(playerInput.GetMoveInput().sqrMagnitude);
            playerAnimation.SetSprinting(false);
            playerAnimation.setStarting(false);
        }

        // 카메라 방향에 따른 이동 방향 설정
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        Vector3 moveDirection = cameraForward * input.y + cameraRight * input.x;

        if (moveDirection.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        // 이동 처리
        transform.Translate(moveDirection * (currentSpeed * Time.deltaTime), Space.World);
    }
}