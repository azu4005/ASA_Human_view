using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using UnityEngine;

public class ShowSpatialMeshScript : MonoBehaviour
{
    private void ShowSpatialMesh()
    {
        //��ԃ��b�V���̎擾
        var observer = CoreServices.GetSpatialAwarenessSystemDataProvider<IMixedRealitySpatialAwarenessMeshObserver>();

        //�����̃��b�V����g�ݍ��킹��
        CombineInstance[] combine = new CombineInstance[observer.Meshes.Count];

        var i = 0;
        foreach (SpatialAwarenessMeshObject meshObject in observer.Meshes.Values)
        {
            combine[i].mesh = meshObject.Filter.sharedMesh;
            combine[i].transform = meshObject.Filter.transform.localToWorldMatrix;

            i++;
        }

        //MeshFilter�R���|�[�l���g�̎擾
        var meshFilter = GetComponent<MeshFilter>();

        //MeshFilter�Ƀ��b�V����ݒ�
        meshFilter.mesh.CombineMeshes(combine);
    }

    void Start()
    {
        //�A�v���N��������1�b���ƂɁuShowSpatialMesh�v�����s
        InvokeRepeating("ShowSpatialMesh", 0, 1);
    }
}
