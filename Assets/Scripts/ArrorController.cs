using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrorController : MonoBehaviour
{
    GameObject player;
    GameDirector gameDirector;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameDirector.gameStopFlag) return; //これ以降の処理をskip

        //フレームごとに等速で落下させる
        transform.Translate(0, -0.01f, 0);

        //画面外に出たらオブジェクトを破棄する
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        //当たり判定
        Vector2 p1 = transform.position;  //矢の中心座標
        Vector2 p2 = this.player.transform.position;  //プレイヤの中心座標
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;  //矢の半径
        float r2 = 1.0f;  //プレイやの半径

        if (d < r1 + r2)
        {
            //衝突した場合は矢を消す
            Destroy(gameObject);

            //監督スクリプトにプレイヤと衝突したことを伝える
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHP();
        }
    }
}
