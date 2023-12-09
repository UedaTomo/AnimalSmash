using System.Collections.Generic;
using UnityEngine;

//MonoBehaviourを継承しないクラスはUnity上でアタッチできない
public class RefrectionLinePoints
{
    public List<Vector3> RefrectionLinePoses(Vector3 position, Vector3 direction, float length, int refrectionCount, LayerMask layerMask)
    {
        //線を引くための頂点のリスト
        var points = new List<Vector3>() { position };
        //反射回数を数える
        int count = 0;
        //レイが当たり続ける限りループ
        while (Physics.Raycast(position, direction, out var hit, length, layerMask) && refrectionCount >= count)
        {
            //レイの衝突位置をリストに追加
            position = hit.point;
            points.Add(position);
            length -= hit.distance;
            //反射したベクトル
            direction = Vector3.Reflect(direction, hit.normal);
            count++;
        }

        return points;
    }
}