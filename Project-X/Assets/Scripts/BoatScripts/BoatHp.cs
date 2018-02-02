using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatHp : MonoBehaviour {

    [SerializeField]
    private int hp, damageAmount;

    int GetHp()
    {
        return hp;
    }

    void Damage(int damage)
    {
        hp -= damage;
        if (hp < 0)
        {
            hp = 0;
            Destroy(gameObject);
            //Instansiate playerCharacter at previousLocation
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
