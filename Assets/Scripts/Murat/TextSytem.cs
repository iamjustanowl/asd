using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSytem : MonoBehaviour
{
    public string[] MetinTexti;
    public Text myText;
    public float TextBeklemSüresi = 15f;
   

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(textChange());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator  textChange(){
        string mahmut;
        for (int i = 0; i < MetinTexti.Length; i++)
        {
            mahmut = MetinTexti[i];

            for (int x = 0; x < mahmut.Length; x++)
            {
                myText.text += mahmut[x];
                yield return new WaitForSeconds(.06f);
            }
            
            yield return new WaitForSeconds(TextBeklemSüresi);
            myText.text = "";
        }
        myText.text = "";
    }
}
