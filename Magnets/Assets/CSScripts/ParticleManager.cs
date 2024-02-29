using UnityEngine;
using System.Collections.Generic;



namespace CSScripts
{
    public class ParticleManager : MonoBehaviour
    {
        public float strenghtForce = 1000;
        private List<ChargedParticle> chargedParticles;
        private List<MovingChargedParticle> movingChargedParticles;

        private float oldTime;
        private float newTime;
        
        private void Start()
        {
            chargedParticles = new List<ChargedParticle>(FindObjectsOfType<ChargedParticle>());
            movingChargedParticles = new List<MovingChargedParticle>(FindObjectsOfType<MovingChargedParticle>());
        }

        private void Update()
        {

            foreach (MovingChargedParticle mcp in movingChargedParticles)
            {
                ApplyMagneticForce(mcp);
            }
            
            
            

        }

        private void ApplyMagneticForce(MovingChargedParticle mcp)
        {
            Vector3 newForce = Vector3.zero;
            Vector3 mcpPosition = mcp.transform.position;
             
            
            foreach (ChargedParticle cp in chargedParticles)
            {
                if (mcp == cp) 
                    continue;
                Vector3 cpPosition = cp.transform.position;
                float distance = Vector3.Distance(mcpPosition, cpPosition);
                float force = strenghtForce * mcp.charge * cp.charge / (distance * distance);
                Vector3 direction = mcpPosition - cpPosition;
                direction.Normalize();
                float finalForce = Time.deltaTime * force;
                newForce += finalForce * direction;
                if (float.IsNaN(newForce.x)) 
                    newForce = Vector3.zero;
                mcp.rb.AddForce((newForce));
            }
        }
    }
}
