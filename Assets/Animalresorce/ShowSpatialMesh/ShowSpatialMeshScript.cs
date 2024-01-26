using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using UnityEngine;

public class ShowSpatialMeshScript : MonoBehaviour
{
    private void ShowSpatialMesh()
    {
        //空間メッシュの取得
        var observer = CoreServices.GetSpatialAwarenessSystemDataProvider<IMixedRealitySpatialAwarenessMeshObserver>();

        //複数のメッシュを組み合わせる
        CombineInstance[] combine = new CombineInstance[observer.Meshes.Count];

        var i = 0;
        foreach (SpatialAwarenessMeshObject meshObject in observer.Meshes.Values)
        {
            combine[i].mesh = meshObject.Filter.sharedMesh;
            combine[i].transform = meshObject.Filter.transform.localToWorldMatrix;

            i++;
        }

        //MeshFilterコンポーネントの取得
        var meshFilter = GetComponent<MeshFilter>();

        //MeshFilterにメッシュを設定
        meshFilter.mesh.CombineMeshes(combine);
    }

    void Start()
    {
        //アプリ起動時から1秒ごとに「ShowSpatialMesh」を実行
        InvokeRepeating("ShowSpatialMesh", 0, 1);
    }
}
