namespace Assets.Src.Game.Fences
{
    using System;

    using UnityEngine;

    public class FenceWonder : MonoBehaviour
    {

        public float Magnitude;

        public float ScaleSpeed;

        public float WonderSpeed;

        private Vector3 start;

        void Start()
        {
            this.start = this.transform.position;
        
        }
	
        // Update is called once per frame
        void Update ()
        {
            var sin = (float)Math.Sin(Time.time * this.WonderSpeed);
            this.transform.position = new Vector3(this.start.x + sin * this.Magnitude, this.start.y, this.start.z);
            var size = 0.4f + ((float)Math.Sin(Time.time * this.ScaleSpeed) + 1) / 8;
            this.transform.localScale = new Vector3(size, size, size);
        }
    }
}
