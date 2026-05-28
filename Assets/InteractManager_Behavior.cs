using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager_Behavior : MonoBehaviour
{
    public Animator anim_0;
    public Animator anim_1;
    public Animator anim_3;
    public Animator anim_4;
    private bool isOpen = false;
    private bool isOpen_1 = false;
    public Material vert_hit;
    public int target_hit = 0;

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if  (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Double_porte_0")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (isOpen == false)
                    {
                        isOpen = true;
                        anim_0.Play("Porte_ouvre_0");
                        anim_1.Play("Porte_ouvre_1");
                    }
                    else
                    {
                        isOpen = false;
                        anim_0.Play("Porte_ferme_0");
                        anim_1.Play("Porte_ferme_1");
                    }
                }
            }
            if (hit.collider.gameObject.tag == "Double_porte_1")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (isOpen_1 == false)
                    {
                        isOpen_1 = true;
                        anim_3.Play("Porte_ouvre_3");
                        anim_4.Play("Porte_ouvre_4");
                    }
                    else
                    {
                        isOpen_1 = false;
                        anim_3.Play("Porte_ferme_3");
                        anim_4.Play("Porte_ferme_4");
                    }
                }
            }

            if (hit.collider.gameObject.tag == "Cible")
            {
                if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.GetComponent<MeshRenderer>().sharedMaterial != vert_hit)
                {
                    target_hit++;
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material = vert_hit;
                }
            }
        }
    }
}
