using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRGIN.Core;

namespace VRGIN.Visuals
{
	// Token: 0x02000087 RID: 135
	[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.MeshRenderer), typeof(global::UnityEngine.MeshFilter))]
	public class ArcRenderer : global::UnityEngine.MonoBehaviour
	{
		// Token: 0x06000210 RID: 528 RVA: 0x0000D610 File Offset: 0x0000B810
		private void Awake()
		{
			this._MeshFilter = base.GetComponent<global::UnityEngine.MeshFilter>();
			this._Renderer = base.GetComponent<global::UnityEngine.Renderer>();
			this._mesh = new global::UnityEngine.Mesh();
			this._Renderer.material = global::VRGIN.Core.VRManager.Instance.Context.Materials.Sprite;
			this._Renderer.shadowCastingMode = 0;
			this._Renderer.receiveShadows = false;
			this._Renderer.useLightProbes = false;
			this._Renderer.material.color = global::VRGIN.Core.VRManager.Instance.Context.PrimaryColor;
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0000D6A8 File Offset: 0x0000B8A8
		public void Update()
		{
			global::UnityEngine.Vector3 forward = base.transform.forward;
			global::System.Collections.Generic.List<global::UnityEngine.Vector3> list = new global::System.Collections.Generic.List<global::UnityEngine.Vector3>();
			global::UnityEngine.Vector3 position = base.transform.position;
			float num = -(this.Velocity * base.transform.forward).y * this.Scale;
			float num2 = global::UnityEngine.Physics.gravity.y * this.Scale;
			float num3 = position.y - this.Offset;
			float num4 = (global::UnityEngine.Mathf.Sqrt(num * num - 2f * num2 * num3) + num) / num2;
			float num5 = (num - global::UnityEngine.Mathf.Sqrt(num * num - 2f * num2 * num3)) / num2;
			float num6 = global::UnityEngine.Mathf.Max(num4, num5);
			num6 = global::UnityEngine.Mathf.Abs(num6);
			float num7 = num6 / (float)this.VertexCount;
			for (int j = 0; j <= this.VertexCount; j++)
			{
				float num8 = global::UnityEngine.Mathf.Clamp((float)j / ((float)this.VertexCount - 1f) * num6 + global::UnityEngine.Time.time * this.UvSpeed % 2f * num7 - num7, 0f, num6);
				list.Add(base.transform.InverseTransformPoint(position + (forward * this.Velocity * num8 + 0.5f * global::UnityEngine.Physics.gravity * num8 * num8) * this.Scale));
			}
			this.target = base.transform.position + (forward * this.Velocity * num6 + 0.5f * global::UnityEngine.Physics.gravity * num6 * num6) * this.Scale;
			this.target.y = 0f;
			base.GetComponent<global::UnityEngine.Renderer>().material.mainTextureOffset += new global::UnityEngine.Vector2(this.UvSpeed * global::UnityEngine.Time.deltaTime, 0f);
			this._mesh.vertices = list.ToArray();
			this._mesh.SetIndices(global::System.Linq.Enumerable.ToArray<int>(global::System.Linq.Enumerable.SelectMany<int, int>(global::System.Linq.Enumerable.Where<int>(global::System.Linq.Enumerable.Select<global::UnityEngine.Vector3, int>(global::System.Linq.Enumerable.Take<global::UnityEngine.Vector3>(list, list.Count - 1), (global::UnityEngine.Vector3 ve, int i) => i), (int i) => i % 2 == 0), (int i) => new int[]
			{
				i,
				i + 1
			})), 3, 0);
			this._MeshFilter.mesh = this._mesh;
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0000D972 File Offset: 0x0000BB72
		private void OnEnable()
		{
			base.GetComponent<global::UnityEngine.Renderer>().enabled = true;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0000D982 File Offset: 0x0000BB82
		private void OnDisable()
		{
			base.GetComponent<global::UnityEngine.Renderer>().enabled = false;
		}

		// Token: 0x040004FF RID: 1279
		public int VertexCount = 50;

		// Token: 0x04000500 RID: 1280
		public float UvSpeed = 5f;

		// Token: 0x04000501 RID: 1281
		public float Velocity = 6f;

		// Token: 0x04000502 RID: 1282
		private global::UnityEngine.MeshFilter _MeshFilter;

		// Token: 0x04000503 RID: 1283
		private global::UnityEngine.Renderer _Renderer;

		// Token: 0x04000504 RID: 1284
		public global::UnityEngine.Vector3 target;

		// Token: 0x04000505 RID: 1285
		public float Offset = 0f;

		// Token: 0x04000506 RID: 1286
		public float Scale = 1f;

		// Token: 0x04000507 RID: 1287
		private global::UnityEngine.Mesh _mesh;
	}
}
