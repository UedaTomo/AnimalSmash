using UnityEngine;
public class LineUpdater : MonoBehaviour
{
    [Header("ラインレンダラー")]
    [SerializeField] private LineRenderer lineRenderer;
    [Header("ラインを出す位置")]
    [SerializeField] private Transform originPos;
    [Header("ラインのながさ")]
    [SerializeField] private float lineLength;
    [Header("反射回数")]
    [SerializeField] private int refrectionCount;
    [Header("レイヤーマスク")]
    [SerializeField] private LayerMask layerMask;

    //LineRendererに指定する座標のリストを作成するクラス
    private RefrectionLinePoints refrectionLinePoints;
    void Start()
    {
        //RefrectionLinePointsクラスをインスタンス化(使えるようにする)
        refrectionLinePoints = new RefrectionLinePoints();
    }

    void Update()
    {
        RefrectionLine();
    }

    void RefrectionLine()
    {
        //座標のリストを取得
        var poses = refrectionLinePoints.RefrectionLinePoses(originPos.position, originPos.forward, lineLength, refrectionCount, layerMask).ToArray();
        //ラインレンダラーに座標の数を指定
        lineRenderer.positionCount = poses.Length;
        //ラインレンダラーに座標のリストを指定
        lineRenderer.SetPositions(poses);
    }
}