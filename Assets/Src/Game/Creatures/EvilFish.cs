namespace Assets.Src.Game.Creatures
{
    using UnityEngine;

    public class EvilFish : MonoBehaviour
    {
        private float Speed = 1f;

        void LateUpdate()
        {
            gameObject.transform.Translate(-Speed*Time.deltaTime,0,0);
        }
    }
}