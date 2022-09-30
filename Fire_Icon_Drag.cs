using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Fire_Icon_Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   // public GameObject Original_Icon; //itemBeingDragged
    public GameObject Cloned_Spell_Icon;



    public Transform begin_transform;
    private Transform Parent_name;
    private RectTransform slot_rect_transform;
    public Transform begin_icon;



    public void OnBeginDrag(PointerEventData eventData)
    {
        begin_transform = transform.parent;
        begin_icon = transform;

        //Debug.Log(begin_transform.name);
        if (Cloned_Spell_Icon == null)
        {
            Cloned_Spell_Icon = Instantiate(gameObject, transform);
            Parent_name = Cloned_Spell_Icon.transform.parent;
            //Debug.Log(Parent_name);
            Cloned_Spell_Icon.name = Parent_name.name;
            Cloned_Spell_Icon.transform.SetParent(Basics.instance.Drag_Front);

        }

        //Cloned_Spell_Icon.transform.SetParent(drag_front.transform);


            GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        
        Cloned_Spell_Icon.transform.position = Input.mousePosition;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {


        List<GameObject> hoveredList = eventData.hovered;


        GetComponent<CanvasGroup>().blocksRaycasts = true;


        //Destroying if dragged off hotbar
        if (begin_transform.parent.name == "Fire_Hotbar")
        {
          //  Debug.Log("from hotbar");
            if (hoveredList.Find(x => x.name == "Fire_Hotbar") == null)
            {
                //PUT POP UP OCNFIRM DELETE ABILITY
                Basics.instance.UI_Drag_Begin = begin_transform.gameObject;
                Basics.instance.Confirm_Delete_Popup.SetActive(true);
                Destroy(Cloned_Spell_Icon.gameObject); //take away getchild(0) to delete both icons

            }
            
            else
            {
                //destroy old drag and swap
                Destroy(begin_transform.transform.GetChild(1).transform.gameObject);
            }
                
        }
        else
        {
            if (hoveredList.Find(x => x.name == "Fire_Hotbar") == null)
            {
                Destroy(Cloned_Spell_Icon.gameObject);

            }
        }

      
    }

}
