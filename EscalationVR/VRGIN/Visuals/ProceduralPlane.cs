using System;
using UnityEngine;

namespace VRGIN.Visuals
{
	// Token: 0x0200008E RID: 142
	[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.MeshFilter))]
	[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.MeshRenderer))]
	public class ProceduralPlane : global::UnityEngine.MonoBehaviour
	{
		// Token: 0x0600024C RID: 588 RVA: 0x0000E71C File Offset: 0x0000C91C
		public void AssignDefaultShader()
		{
			global::UnityEngine.MeshRenderer component = base.gameObject.GetComponent<global::UnityEngine.MeshRenderer>();
			component.sharedMaterial = new global::UnityEngine.Material(global::UnityEngine.Shader.Find("Unlit/Texture"));
			component.sharedMaterial.color = global::UnityEngine.Color.white;
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000E760 File Offset: 0x0000C960
		public void Rebuild()
		{
			this.modelMesh = new global::UnityEngine.Mesh();
			this.modelMesh.name = "ProceduralPlaneMesh";
			this.meshFilter = base.gameObject.GetComponent<global::UnityEngine.MeshFilter>();
			this.meshFilter.mesh = this.modelMesh;
			bool flag = this.xSegments < 1;
			if (flag)
			{
				this.xSegments = 1;
			}
			bool flag2 = this.ySegments < 1;
			if (flag2)
			{
				this.ySegments = 1;
			}
			this.numVertexColumns = this.xSegments + 1;
			this.numVertexRows = this.ySegments + 1;
			int num = this.numVertexColumns * this.numVertexRows;
			int num2 = num;
			int num3 = this.xSegments * this.ySegments * 2;
			int num4 = num3 * 3;
			global::UnityEngine.Vector3[] array = new global::UnityEngine.Vector3[num];
			global::UnityEngine.Vector2[] array2 = new global::UnityEngine.Vector2[num2];
			int[] array3 = new int[num4];
			float num5 = this.width / (float)this.xSegments;
			float num6 = this.height / (float)this.ySegments;
			float num7 = 1f / (float)this.xSegments;
			float num8 = 1f / (float)this.ySegments;
			float num9 = -this.width / 2f;
			float num10 = -this.height / 2f;
			float num11 = this.angleSpan * 3.14159274f / 180f;
			float num12 = 1f;
			float num13 = (float)global::UnityEngine.Screen.width / (float)global::UnityEngine.Screen.height;
			float num14 = num11 / num12;
			for (int i = 0; i < this.numVertexRows; i++)
			{
				for (int j = 0; j < this.numVertexColumns; j++)
				{
					global::UnityEngine.Vector3 vector;
					vector..ctor((float)j * num5 + num9 + this.bottomLeftOffset.x * (float)(this.numVertexColumns - 1 - j) / (float)(this.numVertexColumns - 1) * (float)(this.numVertexRows - 1 - i) / (float)(this.numVertexRows - 1) + this.bottomRightOffset.x * (float)j / (float)(this.numVertexColumns - 1) * (float)(this.numVertexRows - 1 - i) / (float)(this.numVertexRows - 1) + this.topLeftOffset.x * (float)(this.numVertexColumns - 1 - j) / (float)(this.numVertexColumns - 1) * (float)i / (float)(this.numVertexRows - 1) + this.topRightOffset.x * (float)j / (float)(this.numVertexColumns - 1) * (float)i / (float)(this.numVertexRows - 1), (float)i * num6 + num10 + this.bottomLeftOffset.y * (float)(this.numVertexColumns - 1 - j) / (float)(this.numVertexColumns - 1) * (float)(this.numVertexRows - 1 - i) / (float)(this.numVertexRows - 1) + this.bottomRightOffset.y * (float)j / (float)(this.numVertexColumns - 1) * (float)(this.numVertexRows - 1 - i) / (float)(this.numVertexRows - 1) + this.topLeftOffset.y * (float)(this.numVertexColumns - 1 - j) / (float)(this.numVertexColumns - 1) * (float)i / (float)(this.numVertexRows - 1) + this.topRightOffset.y * (float)j / (float)(this.numVertexColumns - 1) * (float)i / (float)(this.numVertexRows - 1) - (this.height - 1f) / 2f, this.distance);
					float num15 = global::UnityEngine.Mathf.Lerp(num13 * this.height * vector.x, global::UnityEngine.Mathf.Cos(1.57079637f - vector.x * num14) * this.distance, global::UnityEngine.Mathf.Clamp01(this.curviness));
					float num16 = global::UnityEngine.Mathf.Sin(1.57079637f - vector.x * num14 * global::UnityEngine.Mathf.Clamp01(this.curviness));
					int num17 = i * this.numVertexColumns + j;
					array[num17] = new global::UnityEngine.Vector3(num15, vector.y, num16);
					bool flag3 = this.curviness > 1f;
					if (flag3)
					{
						float num18 = this.curviness - 1f;
						array[num17] = global::UnityEngine.Vector3.Lerp(array[num17], array[num17].normalized * this.distance, global::UnityEngine.Mathf.Clamp01(num18));
					}
					array2[num17] = new global::UnityEngine.Vector2((float)j * num7, (float)i * num8);
					bool flag4 = i == 0 || j >= this.numVertexColumns - 1;
					if (!flag4)
					{
						int num19 = (i - 1) * this.xSegments * 6 + j * 6;
						array3[num19] = i * this.numVertexColumns + j;
						array3[num19 + 1] = i * this.numVertexColumns + j + 1;
						array3[num19 + 2] = (i - 1) * this.numVertexColumns + j;
						array3[num19 + 3] = (i - 1) * this.numVertexColumns + j;
						array3[num19 + 4] = i * this.numVertexColumns + j + 1;
						array3[num19 + 5] = (i - 1) * this.numVertexColumns + j + 1;
					}
				}
			}
			this.modelMesh.Clear();
			this.modelMesh.vertices = array;
			this.modelMesh.uv = array2;
			this.modelMesh.triangles = array3;
			this.modelMesh.RecalculateNormals();
			this.modelMesh.RecalculateBounds();
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000ECC0 File Offset: 0x0000CEC0
		public float TransformX(float x)
		{
			float num = (float)global::UnityEngine.Screen.width / (float)global::UnityEngine.Screen.height;
			float num2 = this.angleSpan * 3.14159274f / 180f;
			float num3 = 1f;
			return global::UnityEngine.Mathf.Lerp(num * this.height * x, global::UnityEngine.Mathf.Cos(1.57079637f - x * (num2 / num3)) * this.distance, this.curviness);
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000ED28 File Offset: 0x0000CF28
		public float TransformZ(float x)
		{
			float num = (float)global::UnityEngine.Screen.width / (float)global::UnityEngine.Screen.height;
			float num2 = this.angleSpan * 3.14159274f / 180f;
			float num3 = 1f;
			float num4 = num2 / num3;
			return global::UnityEngine.Mathf.Sin(1.57079637f - x * num4 * this.curviness);
		}

		// Token: 0x0400051E RID: 1310
		private const int DEFAULT_X_SEGMENTS = 10;

		// Token: 0x0400051F RID: 1311
		private const int DEFAULT_Y_SEGMENTS = 10;

		// Token: 0x04000520 RID: 1312
		private const int MIN_X_SEGMENTS = 1;

		// Token: 0x04000521 RID: 1313
		private const int MIN_Y_SEGMENTS = 1;

		// Token: 0x04000522 RID: 1314
		private const float DEFAULT_WIDTH = 1f;

		// Token: 0x04000523 RID: 1315
		private const float DEFAULT_HEIGHT = 1f;

		// Token: 0x04000524 RID: 1316
		public int xSegments = 10;

		// Token: 0x04000525 RID: 1317
		public int ySegments = 10;

		// Token: 0x04000526 RID: 1318
		public global::UnityEngine.Vector2 topLeftOffset = global::UnityEngine.Vector2.zero;

		// Token: 0x04000527 RID: 1319
		public global::UnityEngine.Vector2 topRightOffset = global::UnityEngine.Vector2.zero;

		// Token: 0x04000528 RID: 1320
		public global::UnityEngine.Vector2 bottomLeftOffset = global::UnityEngine.Vector2.zero;

		// Token: 0x04000529 RID: 1321
		public global::UnityEngine.Vector2 bottomRightOffset = global::UnityEngine.Vector2.zero;

		// Token: 0x0400052A RID: 1322
		public float distance = 1f;

		// Token: 0x0400052B RID: 1323
		private global::UnityEngine.Mesh modelMesh;

		// Token: 0x0400052C RID: 1324
		private global::UnityEngine.MeshFilter meshFilter;

		// Token: 0x0400052D RID: 1325
		public float width = 1f;

		// Token: 0x0400052E RID: 1326
		public float height = 1f;

		// Token: 0x0400052F RID: 1327
		private int numVertexColumns;

		// Token: 0x04000530 RID: 1328
		private int numVertexRows;

		// Token: 0x04000531 RID: 1329
		public float angleSpan = 160f;

		// Token: 0x04000532 RID: 1330
		public float curviness = 0f;
	}
}
