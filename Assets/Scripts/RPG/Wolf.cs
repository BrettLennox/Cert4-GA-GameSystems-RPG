using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : EnemyMovement
{
    public Material[] wolfSkin = new Material[4];
    public int[] wolfState = new int[6];
    public Renderer renderer;

    public override void Start()
    {
        base.Start();
        difficulty = Random.Range(1, 4);
        attributes[0].maxValue = baseStats[2].value * 5 * difficulty;
        attributes[0].curValue = attributes[0].maxValue;
        baseDamage = baseStats[0].value * 2;
        walkSpeed = baseStats[1].value * 2;
        runSpeed = baseStats[1].value * 2;
        renderer = GetComponentInChildren<Renderer>();
        renderer.material = wolfSkin[difficulty - 1];
    }
    public void BiteAttack()
    {
        int critChance = Random.Range(1, 21);
        float critDamage = 0;
        if(critChance >= critAmount)
        {
            critDamage = Random.Range(baseDamage / 2, baseDamage * difficulty);
        }
        Debug.Log(baseDamage * difficulty + critDamage);
    }
}
