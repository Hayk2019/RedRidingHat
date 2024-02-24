using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MagicalAbility { 

}

public abstract class Weapon
{
    public abstract void Shot();
    public abstract void Reload();
}

public class Blade : Weapon {
    override public void Shot() {
        Debug.Log("Blade:Shot");
    }
    override public void Reload() {
        Debug.Log("Blade:Reload");
    }
}

public class Inventary  {
}


public class RedHat
{
    public RedHat(int health, int magicMana, MagicalAbility abl1, MagicalAbility abl2, Weapon weapon, Inventary inventory)
    {
        
        this.Health = health;
        this.MaginManna = magicMana;
        m1 = abl1;
        m2 = abl2;
        w1 = weapon;
        inventory_ = inventory;
    }
    public void Attack()
    {
        w1.Shot();
    }
    int health_;
    int magicManna_;

    public int Health
    {
        get {
            return health_;
        }
        set {
            if (value > 0)
            {
                health_ = value;
            }
            else {
                health_ = 0;
            }
        }
    }
    public int MaginManna
    {
        get
        {
            return magicManna_;
        }
        set
        {
            if (value > 0)
            {
                magicManna_ = value;
            }
            else {
                magicManna_ = 0;
            }
        }

    }
    MagicalAbility m1;
    MagicalAbility m2;
    Weapon w1;
    Inventary inventory_;
}
public class PlayerParameters : MonoBehaviour {
    [SerializeField] int Health;
    [SerializeField] int MagicManna;
    RedHat myRedHat;
    public Weapon zenq;
    [SerializeField] Sprite MagicManaImage;
    [SerializeField] Sprite HealthImage;
    public void Start()
    {
        zenq = new Blade();
        MagicalAbility m1 = new MagicalAbility();
        MagicalAbility m2 = new MagicalAbility();
        Inventary i1 = new Inventary();
        myRedHat = new RedHat(Health, MagicManna, m1, m2, zenq, i1);
    }

    public void Attack()
    {
        myRedHat.Attack();
    }

}