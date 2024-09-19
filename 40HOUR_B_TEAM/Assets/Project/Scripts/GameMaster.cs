using System.Collections;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private const float DrawStartTextTime = 0.15f;

    private const float DrawRoundTextTime = 1.35f;

    private const float RoomMovementTime = 1.5f;

    private const float CloseCurtainTime = 1.4f;

    private const float OpenCurtainTime = 0.1f;

    private const float SignaturePoseTime = 1.0f;

    private const float ReactionTime = 1.5f;

    private const float ForwardMovementTime = 0.75f;

    private void Start()
    {
        StartCoroutine(DrawRoundText());
    }

    private IEnumerator DrawRoundText()
    {
        // スタートテキスト表示（ラウンド１のみ）

        yield return new WaitForSeconds(DrawStartTextTime);

        // スタートテキスト非表示
        // ラウンドテキスト表示

        yield return new WaitForSeconds(DrawRoundTextTime);

        // ラウンドテキスト非表示
        // ボタンUI表示
    }

    // 各プレイヤーが帽子を選択した際に実行
    // 全プレイヤーが帽子を選択する、もしくは時間切れでボタンUI非表示
    private IEnumerator MovementRoom()
    {
        // 衣装部屋に移動するアニメーション

        yield return new WaitForSeconds(RoomMovementTime);

        // カーテンを下すアニメーション
    }

    // 全プレイヤーが衣装部屋に入った後に実行
    private IEnumerator HatShowTime()
    {
        // カメラズーム処理後にスタート

        yield return new WaitForSeconds(CloseCurtainTime);

        // カーテンを開くアニメーション

        yield return new WaitForSeconds(OpenCurtainTime);

        // 決めポーズアニメーション

        yield return new WaitForSeconds(SignaturePoseTime);

        // リアクションアニメーション
        // 加算スコアテキスト表示

        yield return new WaitForSeconds(ReactionTime);

        // 帽子をランダム再生成
        // プレイヤーが前に移動してくるアニメーション
        // カメラがズームアウトする

        yield return new WaitForSeconds(ForwardMovementTime);

        // ラウンドカウントを増やす
    }
}
