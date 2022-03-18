using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManage : MonoBehaviour
{
    [SerializeField] InputField nameText;
    [SerializeField] InputField amountText;
    [SerializeField] Fruit fruit_fr;
    [SerializeField] GridLayoutGroup itemPenal;
    GameObject[] frList = new GameObject[100];

    fruit[] fr = new fruit[100];
    int i=0;
    bool dubli = false;

    public void Submit()
    {
        if(nameText.text != "")
        {
            for(int j = 0; j < i;j++)
            {
                if(nameText.text.ToUpper().Equals(fr[j].name.ToUpper()))
                {
                    fr[j].amount += int.Parse(amountText.text);
                    dubli = true;
                }
            }

            if(dubli == false)
            {
                fr[i].name = nameText.text;
                fr[i].amount = int.Parse(amountText.text);
                i++;
            }

            dubli = false;
            nameText.text = "";
            amountText.text = "";
        }      
    }
    public void Save()
    {
        PlayerPrefs.SetInt("numberFruit", i);
        for (int j=0; j<i; j++)
        {
            PlayerPrefs.SetString("name"+j.ToString(), fr[j].name);
            PlayerPrefs.SetInt("amount"+j.ToString(), fr[j].amount);
        }
    }

    public void Load()
    {
        HideAllList();
        int temp = PlayerPrefs.GetInt("numberFruit");
        int j;
        for (j = 0; j < temp; j++)
        {
            fr[j].name = PlayerPrefs.GetString("name" + j.ToString());
            fr[j].amount = PlayerPrefs.GetInt("amount" + j.ToString());
        }
        for (int k = j+1; k < i; j++)
        {
            fr[j].name = "";
            fr[j].amount = 0;
        }
        i = temp;
    }

    public void Show()
    {
        HideAllList();
        for (int j = 0; j < i; j++)
        {
            fruit_fr.fr_name.text = fr[j].name;
            fruit_fr.fr_amount.text = fr[j].amount.ToString();
            frList[j] = Instantiate(fruit_fr, itemPenal.transform).gameObject;
        }      
    }

    public void HideAllList()
    {
        for (int k = 0; k < i; k++)
        {
            Destroy(frList[k]);
        }
    }
}

struct fruit
{
    public string name;
    public int amount;
}
