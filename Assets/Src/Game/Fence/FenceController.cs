namespace Assets.Src.Game.Fences
{
    using System;
    using System.Collections.Generic;

    using UnityEngine;

    public class FenceController : MonoBehaviour
    {

        public List<GameObject> Fences;

        public Transform parent;

        // Use this for initialization
        void Start () {
            foreach (var fence in Fences)
            {
                var magnitude = 0f;
                var scale = UnityEngine.Random.value * 2f +0.5f;
                var speed = UnityEngine.Random.value + 0.5f;

                InitFence(fence.GetComponent<FenceWonder>(), scale, speed, magnitude);
                for (int i = 1; i < 80; i++)
                {
                    var pos = fence.transform.position;
                    var next = Instantiate(fence.gameObject, new Vector3(pos.x + i, pos.y, pos.z), Quaternion.identity) as GameObject;
                    next.transform.parent = parent;
                    var wonder = next.GetComponent<FenceWonder>();
                    InitFence(wonder, scale, speed, magnitude);
                }
            }
        }

        private void InitFence(FenceWonder fence, float scale, float speed, float magnitude)
        {
            fence.ScaleSpeed = scale;
            fence.WonderSpeed = speed;
            fence.Magnitude = magnitude;
        }

    }
}
