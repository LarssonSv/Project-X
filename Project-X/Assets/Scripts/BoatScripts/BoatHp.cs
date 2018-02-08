using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatHp : MonoBehaviour {

    [SerializeField]
    private int startHp, damageAmount;
    private int hp;
    [SerializeField]
    private Image bar;
    private List<Vector3> lastPos;
    private int i = 0;
    private bool knockback = false;

    private void Start()
    {
        lastPos = new List<Vector3>();
        hp = startHp;
        bar = GameObject.FindGameObjectWithTag("HpBar").GetComponent<Image>();
        bar.fillAmount = hp * 0.01f;
    }

    private void Update() 
    {
        if (!knockback) 
        {
            lastPos.Insert(0, transform.position);
            if (lastPos.Count > Mathf.Round(0.5f / Time.fixedDeltaTime))
            {
                lastPos.RemoveAt(lastPos.Count -1);
            }
        }
        else if (lastPos.Count > 0) 
        {
            transform.position = lastPos[0];
            lastPos.RemoveAt(0);
        }
        else
        {
            knockback = false;
        }
    }

    public void RestoreHp()
    {
        hp = startHp;
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
       // transform.position = Vector3.Lerp(transform.position, lastPos[99].position, 1f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Danger")
        {
            knockback = true;
            Damage(damageAmount);
        }      
    }
}
