using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{


    protected override void OnCollect()
    {
        //PlayCoinVFX();
        base.OnCollect();

        ItemManager.Instance.AddCoins();

    }
    /*
    public void PlayCoinVFX()
    {
        VFXManager.Instance.PlayVFXByType(VFXManager.VFXType.COIN, transform.position);
    }
    */

}
