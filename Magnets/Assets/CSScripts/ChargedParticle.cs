using UnityEngine;

namespace CSScripts
{
  public class ChargedParticle : MonoBehaviour
  {
    public float charge = 1;

    private void Start()
    {
      UpdateColor();
    }

    protected void UpdateColor()
    {
      Color color = charge > 0 ? Color.green : Color.red;
      GetComponent<Renderer>().material.color = color;
    }
  }
}
