using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameDirector gameDirector;
    Vector2 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameDirector.gameStopFlag) return; //これ以降の処理をskip
        
        //左矢印が押された時
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-3, 0, 0); //左へ動かす
        }
        //右矢印が押された時
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(3, 0, 0); //右へ動かす
        }

        //プレイヤー移動範囲制限
        playerPos = transform.position; //プレイヤーの位置を取得
        playerPos.x = Mathf.Clamp(playerPos.x, -6, 6); //x位置が常に範囲内か監視
        transform.position = new Vector2(playerPos.x, playerPos.y); //範囲内であれば常にその位置がそのまま入る
    }
}
