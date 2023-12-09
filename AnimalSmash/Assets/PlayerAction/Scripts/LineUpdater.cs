using UnityEngine;
// using UnityEngine.InputSystem;
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
    [Header("回転速度")]
    [SerializeField] private float rotationSpeed;

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
        //LookPosition();
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

    //void LookPosition()
    //{
        // マウスの移動量を取得
        //float mouseX = Input.GetAxis("Mouse X");

        // マウスの移動量を使ってオブジェクトを回転させる
        //transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.deltaTime, Space.World);


        //Input Sysytemを使用している場合はコメントアウトを解除して使ってください(上のusing部分も)

        // //マウスの移動量を取得(InputSystem)
        // Vector3 mouseDelta = Mouse.current.delta.ReadValue();

        // // マウスの移動量を使ってオブジェクトを回転させる
        // transform.Rotate(Vector3.up, mouseDelta.x * rotationSpeed * Time.deltaTime, Space.World);
    //}

}