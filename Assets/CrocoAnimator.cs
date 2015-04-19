using UnityEngine;
using System.Collections;

public class CrocoAnimator : MonoBehaviour
{

    public Animator anim;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.N))
	    {
	        Debug.Log("N!");
            anim.SetTrigger("Open");
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("M!");
            anim.SetTrigger("Open");
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("L!");
            anim.SetBool("Sleep", true);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("K!");
            anim.SetBool("Sleep", false);
        }
	}

    public void OpenCrocoMouth()
    {
	    anim.ResetTrigger("Close");
        anim.SetTrigger("Open");
    }

    public void CloseCrocoMouth()
    {
        anim.SetTrigger("Close");
    }

	public void Sleep()
	{
		anim.SetBool("Sleep", true);
	}

	public void WakeUp()
	{
		anim.SetBool("Sleep", false);
	}

    public void Die()
    {
        anim.SetBool("Die", true);
    }
}
