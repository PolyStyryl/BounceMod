using UnityEngine;

namespace Bounce
{
    public class BounceBehaviour : MonoBehaviour
    {
        private float _triggerStart;
        private const float TriggerCooldown = 0.1f;
        private const float BounceForce = 10f;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out BounceBehaviour _)) return;  // If not colliding with player, return

            if (!gameObject.TryGetComponent(out Rigidbody thisRigidbody) ||
                !other.TryGetComponent(out Rigidbody otherRigidbody)) return; // Check we can get both rigidbodies

            if (!(Time.time > _triggerStart + TriggerCooldown)) return;
            
            var direction = thisRigidbody.position - otherRigidbody.position;
            var totalForce = direction + thisRigidbody.velocity * BounceForce;
                
            otherRigidbody.AddForce(totalForce, ForceMode.Impulse);

            _triggerStart = Time.time;  // Update cooldown
        }
    }
}