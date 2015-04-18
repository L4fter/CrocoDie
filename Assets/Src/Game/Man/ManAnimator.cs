namespace Assets.Src.Game.Pers
{
    using UnityEngine;

    public class ManAnimator : MonoBehaviour
    {
        public Animator anim;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Q");
                anim.SetTrigger("MakeMove");
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("W!");
                anim.SetTrigger("MidKick");
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E!");
                anim.SetTrigger("HighKick");
            }
        }

        public void LowKick()
        {
            anim.SetTrigger("MakeMove");
        }

        public void MidKick()
        {
            anim.SetTrigger("MidKick");
        }

        public void HighKick()
        {
            anim.SetTrigger("HighKick");
        }

    }
}