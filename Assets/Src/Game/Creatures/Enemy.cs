namespace Assets.Src.Game.Creatures
{
    using UnityEngine;

    public class Enemy : MonoBehaviour
    {
        public GameObject Prefab;

        public Animator Animator;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                this.Throw();
            }
        }

        public void Throw()
        {
            var v = Instantiate(Prefab, gameObject.transform.position, Quaternion.identity);
            Animator.SetBool("Die", true);
        }
    }
}