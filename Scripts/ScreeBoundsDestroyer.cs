using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreeBoundsDestroyer : MonoBehaviour
{
    public void TestColliderDestruction(Collider2D collider)
    {
        ScreenBoundsDestroyTrigger trigger = collider.GetComponent<ScreenBoundsDestroyTrigger>();
        if (trigger != null)
        {
            trigger.OnOutOfBoundsDestruction?.Invoke();
            Destroy(collider.gameObject);
        }
    }
}
