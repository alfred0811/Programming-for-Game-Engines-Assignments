using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private int groundContacts = 0;
    public bool isGrounded { get { return groundContacts > 0; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ++groundContacts;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        --groundContacts;
    }
}
