using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GemData gemData;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        switch (gemData.rarity)
        {
            case Rarity.Common:
                sr.color = Color.white;
                break;

            case Rarity.Rare:
                sr.color = Color.green;
                break;

            case Rarity.Epic:
                sr.color = Color.blue;
                break;

            case Rarity.Legendary:
                sr.color = new Color( 1f, .64f, 0 );
                break;

            case Rarity.Mythical:
                sr.color = new Color( .5f, 0, .5f );
                break;

            default:
                Debug.Log("This gem's rarity was never assigned");
                sr.color = Color.gray;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual public void RerollLines()
    {
        foreach (var mod in gemData.modifiers)
        {
            Debug.Log("Rerolling " + mod);
        }
    }

    virtual public void ApplyModifier(Tower tower)
    {

    }

    virtual public void UpgradeRarity(Rarity upgrade)
    {
        if (upgrade > this.gemData.rarity)
        {
            gemData.rarity = upgrade;
        }
        else
        {
            Debug.Log("Passed in rarity upgrade lower than current rarity");
        }
    }

}
