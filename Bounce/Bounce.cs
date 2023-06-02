using System.Linq;
using Kitchen;
using KitchenMods;
using UnityEngine;

namespace Bounce
{
    public class Bounce : GenericSystemBase, IModSystem
    {
        protected override void Initialise()
        {
            base.Initialise();
            Debug.Log("Bounce v0.1 Initialised...");
        }

        protected override void OnUpdate()
        {
            var playerModels = Object.FindObjectsOfType<GameObject>().Where(x => x.name == "Player(Clone)");

            foreach (var playerModel in playerModels)
            {
                if (playerModel.GetComponents<CapsuleCollider>()
                        .SingleOrDefault(x => x.isTrigger) != null)
                {
                    continue;  // Already has a CapsuleCollider with a trigger
                }
                
                Debug.Log("Creating BounceCollider...");
                CapsuleCollider capsuleCollider = playerModel.AddComponent<CapsuleCollider>();
                capsuleCollider.radius = 0.4f;
                capsuleCollider.height = 1.49f;
                capsuleCollider.isTrigger = true;
                playerModel.AddComponent<BounceBehaviour>();
            }
        }
    }
}