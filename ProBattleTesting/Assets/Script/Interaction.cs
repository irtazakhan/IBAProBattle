using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Interaction : MonoBehaviour
{
    public float Range = 5f;
    public GameObject DoorPanel;
    public GameObject LetterB;
    public GameObject[] KeyPad;
    public Text KeyPadText;

    int count = 0;
    string finalCode = "IBA";
    string str1, str2, str3;
    string[] str = { "", "", "" };
    string code;
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, Range))
		{
			
				if (hit.collider.CompareTag("Bear"))
				{

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponentInParent<Animator>().SetTrigger("Fall");
                    LetterB.SetActive(true);
                }

				}
               if (hit.collider.CompareTag("Drawer"))
                {
                if (Input.GetKeyDown(KeyCode.E))
                 {
                    hit.collider.gameObject.GetComponentInParent<Animator>().SetTrigger("Open");
                 }
                }
               if (hit.collider.CompareTag("Picture"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                    hit.collider.gameObject.GetComponentInParent<Animator>().SetTrigger("Slide");
                }
                }
            if (hit.collider.gameObject.CompareTag("Clock"))
            {
                activateImage(0);
            }

            if (hit.collider.gameObject.CompareTag("B"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    activateImage(1);
                }
            }

            if (hit.collider.gameObject.CompareTag("Door"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    OpenDoor();
                }
            }

		}
    }

    void activateImage(int index)
    {
        for(int i = 0; i < KeyPad.Length; i++)
        {
            if (i == index)
            {
                KeyPad[i].SetActive(true);
                count++;
            }
        }
    }

    void OpenDoor()
    {
        GetComponentInParent<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //for (int i = 0; i< KeyPad.Length; i++)
        //{
        //    if (KeyPad[i].activeInHierarchy)
        //    {
        //        count++;
        //    }
        //}

        //if(count == 3)
        //{
        //    Debug.Log("Level Complete");
        //    return;
        //}

        //count = 0;



        DoorPanel.SetActive(true);

    }

    public void EnterCode(string alphabet)
    {
        for(int i = 0; i < str.Length; i++)
        {
            if (str[i] == "")
            {
                str[i] = alphabet;
                KeyPadText.text = str[0] + str[1] + str[2];
                Debug.Log(alphabet);
                return;
            }
        }


    }

    public void UnlockCode()
    {
        code = str[0] + str[1] + str[2];
        if (code == finalCode)
        {
            Debug.Log("Level COmplete");
        }
        else
        {

            for (int i = 0; i < str.Length; i++)
            {
                str[i] = "";
            }

            KeyPadText.text = str[0] + str[1] + str[2];
        }

    }

    public void ClosePanel()
    {
        GetComponentInParent<FirstPersonController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        DoorPanel.SetActive(false);
    }

}
