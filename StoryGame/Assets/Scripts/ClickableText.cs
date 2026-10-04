using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableText : MonoBehaviour
{
    public void OnPointerClick(PointerEventData eventData)
    {
        var text = GetComponent<TextMeshProUGUI>();

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //int linkIndex = TMP_TextUtilites.FindIntersectingLink(text, Input.mousePosition, null);
            //if (linkIndex > -1)
            //{
            //    var linkInfo = text.textInfo.lineInfo[linkIndex];
            //    var linkId = linkInfo.GetLinkID();

            //    var itemData = FindObjectOfType<ItemDataController>().Get(linkId);

            //    PopupPanel.Show(itemData);
            //}
        }
    }
}
