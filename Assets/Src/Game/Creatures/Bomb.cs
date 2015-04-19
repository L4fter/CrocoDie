namespace Assets.Src.Game.Creatures
{
    using UnityEngine;

    public class Bomb : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (!this.enabled)
            {
                return;
            }

            var croco = collider2D.gameObject.GetComponent<Croco>();

            if (croco != null)
            {
				croco.Explode(3);
               
                //this.SendMessage("Destroy", SendMessageOptions.DontRequireReceiver);
            }

        }
    }
}