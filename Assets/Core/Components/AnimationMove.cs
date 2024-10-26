using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimationMove : MonoBehaviour
{    
    [SerializeField] private Transform endPosition;
    [SerializeField] private GameObject textObject;
    public void AnimateCurrency(float amount)
    {        
        Transform canvas = FindObjectOfType<Canvas>().transform;
        GameObject currencyTextObject = Instantiate(textObject, canvas);     
        TextMeshProUGUI floatingText = currencyTextObject.AddComponent<TextMeshProUGUI>();

        if (amount > 0)
        {
            floatingText.text = "+" + amount.ToString("F2");
        }
        else
        {
            floatingText.text = "No energy";
        }

        currencyTextObject.transform.position = transform.position;
        
        LeanTween.moveLocal(currencyTextObject, new Vector3(Random.Range(-500f,500f), Random.Range(-500f, 500f), 0), 1f).setOnComplete(() => Destroy(currencyTextObject));
    }
}
