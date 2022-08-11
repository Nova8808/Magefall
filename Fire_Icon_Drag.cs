using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Fire_Icon_Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   // public GameObject Original_Icon; //itemBeingDragged
    public GameObject Cloned_Spell_Icon;


    //Vector3 startPosition;
    //Transform startParent;
    //public GameObject drag_front;
    public Transform begin_transform;
    //private GameObject Placed_Icon;
    private Transform Parent_name;
    private RectTransform slot_rect_transform;
    public Transform begin_icon;

    //private GameObject tool_tip;

    private void Awake()
    {
        //drag_front = GameObject.Find("Drag Holder");
        //tool_tip = GameObject.Find("Tooltip");
    }
    private void OnDisable()
    {


        //for (int x = 0; x < drag_front.transform.childCount; x++)
        //{
        //   Destroy(drag_front.transform.GetChild(x).transform.gameObject);
        //}
    }

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
            //slot_rect_transform = Cloned_Spell_Icon.transform.GetComponent<RectTransform>();
            //Vector3 scaler_vector = new Vector3(1.3f, 1.3f, 1.3f);
            //slot_rect_transform.localScale = scaler_vector;
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

        // item = null;
       // Vector3 NewParentPosition = Cloned_Spell_Icon.transform.parent.position;
        List<GameObject> hoveredList = eventData.hovered;

        //if (hoveredList.Find(x => x.name == "Frame") == null)
        //{

        //        Debug.Log(transform.GetChild(0).gameObject);
        //   // Cloned_Spell_Icon.transform.SetParent(drag_front.transform);
        //   // Destroy(transform.GetChild(0).gameObject);
        //    }
        //else
        //{

        //   // Cloned_Spell_Icon.transform.position = NewParentPosition;
        //    Cloned_Spell_Icon.name = Parent_name.name;
        //}
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        // Debug.Log(begin_transform.parent.name);
        // Debug.Log(Parent_name.name);

        //for (int i = 0; i < hoveredList.Count; i++)
        //{
        //    Debug.Log(hoveredList[i]);
        //}

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
                // Parent_name.transform.SetParent(drag_front.transform);
                //Parent_name.transform.position = drag_front.transform.position;
                //Cloned_Spell_Icon.transform.SetParent(drag_front.transform);

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
                //Destroy(transform.GetChild(0).gameObject);
                //Cloned_Spell_Icon.transform.SetParent(drag_front.transform);
                //Cloned_Spell_Icon.transform.SetParent(begin_transform);
               // Destroy(Cloned_Spell_Icon);
            }
        }

        //public void OnPointerEnter(PointerEventData eventData)
        //{
        //    //if eventdata  raycast info is item_clone

        //    tool_tip.transform.GetChild(1).transform.gameObject.SetActive(true);
        //    //tool_tip.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = item.name;
        //    //tool_tip.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = item.amount.ToString();
        //    //tool_tip.transform.GetChild(1).GetChild(2).GetComponent<Text>().text = item.Shield_Power.ToString();
        //    tool_tip.transform.GetChild(1).transform.position = new Vector2(transform.position.x + 170, transform.position.y);


        //    // Debug.Log("hovered");

        //}

        //public void OnPointerExit(PointerEventData eventData)
        //{
        //    tool_tip.transform.GetChild(0).transform.gameObject.SetActive(false);
        //}


        //// if (item2.transform.parent == )
        ////if (Cloned_Spell_Icon.transform.parent == startParent || Cloned_Spell_Icon.transform.parent.parent.parent.parent.name == "Canvas - Spell Menu" || Cloned_Spell_Icon.transform.parent.parent.name != "Fire_Hotbar")
        ////{
        ////    item2.transform = startPosition;
        ////    if (Cloned_Spell_Icon.transform.parent.parent.parent.parent.name == "Canvas - Hotbar")
        ////    {
        ////        Destroy(Cloned_Spell_Icon.transform.parent.gameObject);
        ////    }
        ////    Destroy(Cloned_Spell_Icon.transform.gameObject);


        ////}
        ////if (Cloned_Spell_Icon.transform.parent.parent.name == "Fire_Hotbar")
        ////{
        ////    Destroy(Cloned_Spell_Icon.transform.gameObject);
        ////    Cloned_Spell_Icon.transform.position = NewParentPosition;

        ////}
        ////if (item2.transform.parent.parent.name == "SpellMenu")
        ////{
        ////    Destroy(item.gameObject);
        ////}
        ////else
        ////{
        ////    Cloned_Spell_Icon.transform.position = NewParentPosition;
        ////}
        ////GetComponent<CanvasGroup>().blocksRaycasts = true;

    }

}