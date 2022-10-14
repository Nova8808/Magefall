using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class SlotDrop : MonoBehaviour, IDropHandler
{
    public GameObject Icon_Clone;
    public GameObject old_parent;
    //private GameObject drag_front;
    private RectTransform slot_rect_transform;
    private Transform slotted_icon;
    private Transform parent_slot;


    public void OnDrop(PointerEventData eventData)
    {
        List<GameObject> hoveredList = eventData.hovered;
        //bool fullcheck = false;
        // Icon_Clone = GameObject.Find("Cloned_Spell_Icon");
        
        //----FIX THIS PART
        if (eventData.pointerDrag.GetComponent<Fire_Icon_Drag>())
        {
            Icon_Clone = eventData.pointerDrag.GetComponent<Fire_Icon_Drag>().Cloned_Spell_Icon;
            parent_slot = eventData.pointerDrag.GetComponent<Fire_Icon_Drag>().begin_transform;
        }


        //for (int x =0; x < hoveredList.Count; x++)
        //{
        //    Debug.Log(hoveredList[x]);
        //}

        

        if (transform.name != "Spell_Selection")
        {
            if (transform.childCount > 1)
            {
                slotted_icon = transform.GetChild(1).transform;
                //original_slot = Icon_Clone.transform.parent.parent.GetSiblingIndex();
                //Debug.Log(original_slot);
                Icon_Clone.transform.SetParent(transform);
                Icon_Clone.transform.position = transform.position;
               

                slotted_icon.SetParent(parent_slot);
                slotted_icon.transform.position = parent_slot.transform.position;

                //Destroy(Icon_Clone.transform.parent.GetChild(1).gameObject);
                //Icon_Clone.transform.parent.GetChild(1).gameObject.transform.position = transform.parent.GetChild(original_slot).transform.position;
                //Icon_Clone.transform.parent.GetChild(1).gameObject.transform.SetParent(transform.parent.GetChild(original_slot));

            }
            else
            {
                Icon_Clone.transform.SetParent(transform);
                Icon_Clone.transform.position = transform.position;
                //if (parent_slot.parent.name != "Spell_Menu")
                //{
                //    Destroy(parent_slot.transform.GetChild(1).transform.gameObject);
                //}

            }

            //if (transform.GetChild(1) != null)
            //{
            //    slot_rect_transform = transform.GetChild(1).GetComponent<RectTransform>();
            //    Vector3 scaler_vector = new Vector3(1.3f, 1.3f, 1.3f);
            //    slot_rect_transform.localScale = scaler_vector;
            //}
        }

        //else
        //{
        //    Icon_Clone.transform.SetParent(Icon_Clone.transform);
        //    Icon_Clone.transform.position = Icon_Clone.transform.parent.position;
        //}


        //transform.GetChild(1).transform.localScale.x = 1;
        //transform.GetComponent<RectTransform>().localScale.x = 1;


        //    //Destroy(Icon_Clone.transform.gameObject);
        //    fullcheck = true;
        //    old_parent = Icon_Clone.transform.parent.gameObject;
        //    Icon_Clone.transform.SetParent(transform);
        //    Icon_Clone.name = old_parent.name;

        //    Icon_Clone.transform.position = Icon_Clone.transform.parent.position;
        //    if (old_parent.transform.parent.parent.parent.name == "Canvas - Hotbar")
        //    {
        //        Destroy(old_parent.gameObject);
        //    }
        //    Destroy(Icon_Clone.transform.parent.GetChild(1).gameObject);

        //    //Icon_Clone.transform.position = Icon_Clone.transform.parent.position;

        //}
        //else if (!fullcheck)
        //{.
        //    old_parent = Icon_Clone.transform.parent.gameObject;

        //    Icon_Clone.transform.SetParent(transform);
        //    Icon_Clone.name = old_parent.name;

        //    if (old_parent.transform.parent.parent.parent.name == "Canvas - Hotbar")
        //    {
        //        Destroy(old_parent.gameObject);
        //        Icon_Clone.transform.position = Icon_Clone.transform.parent.position;
        //    }


    }
}
        //public GameObject Get_Icon()
        //{
        //    GameObject _current_icon;
        //}
    
