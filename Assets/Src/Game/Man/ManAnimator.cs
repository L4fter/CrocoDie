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
                anim.SetBool("Move", false);
            }
        }

        public void LowKick()
        {
            anim.SetTrigger("MakeMove");
        }

        public void CloseCrocoMouth()
        {
            anim.SetBool("Open", false);
        } 
    }
}