
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ClosingDors : IPassiveDevice
{
        // Start is called before the first frame update
        protected override void isPowered()
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
            GetComponent<ShadowCaster2D>().enabled = true;
           
        }
        protected override void isDepowered()
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<ShadowCaster2D>().enabled = false;
        }
    
}
