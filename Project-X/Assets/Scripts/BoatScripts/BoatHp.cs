using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatHp : MonoBehaviour {

    [SerializeField]
    private int hp, damageAmount;

    private Image bar;

    private void Start()
    {
        bar = GameObject.FindGameObjectWithTag("HpBar").GetComponent<Image>();
        bar.fillAmount = hp * 0.01f;
    }

    public int GetHp()
    {
        return hp;
    }

    void Damage(int damage)
    {
        hp -= damage;
        bar.fillAmount = hp * 0.01f;

        if (hp <= 0)
        {
            Destroy(gameObject);
            GameObject.Find("CheckPoint").GetComponent<CheckPointScript>().OnCharacterDeath();
            hp = 50;
            bar.fillAmount = hp * 0.01f;
            GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<Image>().fillAmount = 0.5f;
            GameObject.FindGameObjectWithTag("FuelBar").GetComponent<Image>().fillAmount = 0.0f;
            Debug.Log("Boat destroyed, you were knocked out and awoke on the last island you visited.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Danger")
        {
            Damage(damageAmount);
        }      
    }
}
