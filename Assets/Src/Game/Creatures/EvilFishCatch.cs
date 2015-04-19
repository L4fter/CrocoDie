namespace Assets.Src.Game.Creatures
{
    using UnityEngine;

    public class EvilFishCatch : MonoBehaviour
    {
        public EvilFish fish;


        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            var tag = collider2D.gameObject.tag;
            if (tag == "PlayerCroco")
            {
                fish.SpeedUp();
            }
        }
    }
}