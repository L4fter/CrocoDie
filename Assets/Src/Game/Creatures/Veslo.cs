namespace Assets.Src.Game.Creatures
{
    using System;

    using UnityEngine;

    public class Veslo : MonoBehaviour
    {
        private float rand;

        private float Speed = 8;

        void Start()
        {
            rand = UnityEngine.Random.value - 1;
        }

        void Update()
        {
            gameObject.transform.Rotate(0,0,16);
            var pos = gameObject.transform.position;
            Destroy(gameObject, 5);
            gameObject.transform.position = new Vector3(pos.x + Time.deltaTime * rand * Speed, pos.y + Time.deltaTime * Speed, pos.z);
        }
    }
}