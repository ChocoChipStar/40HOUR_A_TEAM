using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField]
    private RoundCounter roundCounter = null;

    [SerializeField]
    private InputButtonManager inputButtonManager = null;

    [SerializeField]
    private ScoreManager scoreManager = null;

    [SerializeField]
    private HatGenerator hatManager = null;

    [SerializeField]
    private HatCover hatCover = null;

    [SerializeField]
    private MannequinManager mannequinManager = null;

    [SerializeField]
    private PlayerMover[] playerMover = null;

    [SerializeField]
    private CurtainMover[] curtainMover = null;

    private bool isLastFrameActive = false;

    private const float DrawStartTextTime = 0.15f;

    private const float DrawRoundTextTime = 1.35f;

    private const float RoomMovementTime = 1.5f;

    private const float CloseCurtainTime = 1.4f;

    private const float OpenCurtainTime = 0.25f;

    private const float ShowcaseMovementTime = 0.75f;

    private const float CoolPoseTime = 1.0f;

    private const float ReactionTime = 1.5f;

    private const float IntervalTime = 1.0f;

    private const float ThinkingMovementTime = 0.75f;

    private void Start()
    {
        // マネキン生成
        mannequinManager.GenerateMannequin(roundCounter.GetCurrentRound());
        // ぼうし生成
        hatManager.LineUpHat(roundCounter.GetCurrentRound());

        StartCoroutine(DrawRoundText());
    }

    private void Update()
    {
        if(inputButtonManager.isAllPlayerSelectedButton != isLastFrameActive)
        {
            StartCoroutine(MovementRoom());

            isLastFrameActive = inputButtonManager.isAllPlayerSelectedButton;
        }
    }

    private IEnumerator DrawRoundText()
    {
        // スタートテキスト表示（ラウンド１のみ）

        yield return new WaitForSeconds(DrawStartTextTime);

        // スタートテキスト非表示
        // ラウンドテキスト表示

        yield return new WaitForSeconds(DrawRoundTextTime);

        // ラウンドテキスト非表示

        // 入力ボタンデータ初期化
        inputButtonManager.ResetInputButtonData();

        // ボタンUI表示と入力状態ON
        inputButtonManager.DrawButtonUI();
    }

    // 各プレイヤーが帽子を選択した際に実行
    // 全プレイヤーが帽子を選択する、もしくは時間切れでボタンUI非表示
    private IEnumerator MovementRoom()
    {
        // 走りアニメーション

        // 衣装部屋に移動する
        for(int i = 0; i < PlayerData.PlayerMax; i++)
        {
            playerMover[i].isThinkingToRoom = true;
        }
        
        yield return new WaitForSeconds(RoomMovementTime);

        StartCoroutine(HatShowTime());
    }

    // 全プレイヤーが衣装部屋に入った後に実行
    private IEnumerator HatShowTime()
    {
        // カメラズームイン後にスタート

        // 選択したぼうしをプレイヤーモデルに配置
        hatCover.CoveringHat();

        // 選択したぼうしがスコア何点のぼうしか確認する
        scoreManager.ConvertButtonNumToScore();

        yield return new WaitForSeconds(CloseCurtainTime);

        // カーテンを開く待機時間
        for (int i = 0; i < PlayerData.PlayerMax; i++)
        {
            curtainMover[i].isOpen = true;
        }

        yield return new WaitForSeconds(OpenCurtainTime);

        // 決めポーズアニメーション

        yield return new WaitForSeconds(CoolPoseTime);

        // 走りアニメーション再生

        // お披露目場所に移動する
        for (int i = 0; i < PlayerData.PlayerMax; i++)
        {
            playerMover[i].isRoomToShowcase = true;
        }
        
        yield return new WaitForSeconds(ShowcaseMovementTime);

        // 一秒待機
        yield return new WaitForSeconds(IntervalTime);

        // ぼうしが被らなかったアニメーション


        // ぼうしが被ったアニメーション


        // ぼうしが無かったアニメーション


        // 加算スコアテキスト表示
        for (int i = 0; i < PlayerData.PlayerMax; i++)
        {
            scoreManager.AddScore(i);
        }


        yield return new WaitForSeconds(ReactionTime);

        // マネキンを再配置
        mannequinManager.GenerateMannequin(roundCounter.GetCurrentRound());

        // 帽子をランダム再生成
        hatManager.LineUpHat(roundCounter.GetCurrentRound());

        // ボタンUI再配置
        inputButtonManager.RelocatingButton(roundCounter.GetCurrentRound());

        // 走りアニメーション再生


        // ぼうし選択場所に移動する
        for (int i = 0; i < PlayerData.PlayerMax; i++)
        {
            playerMover[i].isShowcaseToThinking = true;
        }
        
        // カメラがズームアウトする
        

        yield return new WaitForSeconds(ThinkingMovementTime);

        // ラウンドカウントを増やす
        roundCounter.SetNextRound();
    }
}
