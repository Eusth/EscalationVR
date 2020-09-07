using System;
using System.Collections.Generic;
using UnityEngine;

namespace VRGIN.Helpers
{
	// Token: 0x020000DA RID: 218
	public static class MeshExtension
	{
		// Token: 0x0600057D RID: 1405 RVA: 0x0001B524 File Offset: 0x00019724
		public static global::UnityEngine.Vector3 GetBarycentric(global::UnityEngine.Vector2 v1, global::UnityEngine.Vector2 v2, global::UnityEngine.Vector2 v3, global::UnityEngine.Vector2 p)
		{
			global::UnityEngine.Vector3 vector = default(global::UnityEngine.Vector3);
			vector.x = ((v2.y - v3.y) * (p.x - v3.x) + (v3.x - v2.x) * (p.y - v3.y)) / ((v2.y - v3.y) * (v1.x - v3.x) + (v3.x - v2.x) * (v1.y - v3.y));
			vector.y = ((v3.y - v1.y) * (p.x - v3.x) + (v1.x - v3.x) * (p.y - v3.y)) / ((v3.y - v1.y) * (v2.x - v3.x) + (v1.x - v3.x) * (v2.y - v3.y));
			vector.z = 1f - vector.x - vector.y;
			return vector;
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x0001B648 File Offset: 0x00019848
		public static bool InTriangle(global::UnityEngine.Vector3 barycentric)
		{
			return barycentric.x >= 0f && barycentric.x <= 1f && barycentric.y >= 0f && barycentric.y <= 1f && barycentric.z >= 0f;
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x0001B6A4 File Offset: 0x000198A4
		public static global::UnityEngine.Vector3[] GetMappedPoints(this global::UnityEngine.Mesh aMesh, global::UnityEngine.Vector2 aUVPos)
		{
			global::System.Collections.Generic.List<global::UnityEngine.Vector3> list = new global::System.Collections.Generic.List<global::UnityEngine.Vector3>();
			global::UnityEngine.Vector3[] vertices = aMesh.vertices;
			global::UnityEngine.Vector2[] uv = aMesh.uv;
			int[] triangles = aMesh.triangles;
			for (int i = 0; i < triangles.Length; i += 3)
			{
				int num = triangles[i];
				int num2 = triangles[i + 1];
				int num3 = triangles[i + 2];
				global::UnityEngine.Vector3 barycentric = global::VRGIN.Helpers.MeshExtension.GetBarycentric(uv[num], uv[num2], uv[num3], aUVPos);
				bool flag = global::VRGIN.Helpers.MeshExtension.InTriangle(barycentric);
				if (flag)
				{
					global::UnityEngine.Vector3 vector = barycentric.x * vertices[num] + barycentric.y * vertices[num2] + barycentric.z * vertices[num3];
					list.Add(vector);
				}
			}
			return list.ToArray();
		}
	}
}
