using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public Vector3 JumpForce;
    private Animator JumpPadAnim;
   
    private void Start()
    {
        JumpPadAnim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<PlayerController>())
        {
            PlayerController.Instance.AddedVelocity = Vector3.up * JumpForce.y + transform.forward * JumpForce.x;
            JumpPadAnim.SetTrigger("Jump");
            // AudioManager.Instance.PlaySFX("jump");
                
           

        }
    }

}
