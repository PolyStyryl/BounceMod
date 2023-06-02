using UnityEngine;

namespace Bounce
{
    public class BounceCollider : MonoBehaviour
    {
        private float _triggerStart;
        private const float TriggerCooldown = 0.2f;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out BounceCollider _)) return;  // If not colliding with player, return

            if (!gameObject.TryGetComponent(out Rigidbody thisRigidbody) ||
                !other.TryGetComponent(out Rigidbody otherRigidbody)) return; // Check we can get both rigidbodys

            if (Time.time > _triggerStart + TriggerCooldown)
            {
                Debug.Log("boop");
                otherRigidbody.AddForce(thisRigidbody.velocity * 3, ForceMode.Impulse);  // Apply force opposite
            
                _triggerStart = Time.time;  // Update cooldown
            } 
        }
    }
}