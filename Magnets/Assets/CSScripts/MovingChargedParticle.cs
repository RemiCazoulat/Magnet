using UnityEngine;

namespace CSScripts
{
    public class MovingChargedParticle : ChargedParticle
    {
        public float mass = 1;

        public Rigidbody rb;
        // Start is called before the first frame update
        private void Start()
        {
            UpdateColor();

            rb = gameObject.AddComponent <Rigidbody>();
            rb.mass = mass;
            rb.useGravity = false;
        }

       
    }
}
