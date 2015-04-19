namespace Assets.Src.Game.Creatures
{
    using UnityEngine;

    public class EvilFish : MonoBehaviour
    {
        private float Speed;

        void LateUpdate()
        {
            Speed *= 1.05f;
            gameObject.transform.Translate(-Speed*Time.deltaTime,0,0);
        }

        public void SpeedUp()
        {
            if (Speed.Equals(0))
            {
                Speed = 1f;
            }
        }
    }
}