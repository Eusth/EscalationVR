using System;
using UnityEngine;
using VRGIN.Core;
using VRGIN.Visuals;

namespace VRGIN.U46.Helpers
{
	// Token: 0x02000099 RID: 153
	public class GuiScaler
	{
		// Token: 0x060002C4 RID: 708 RVA: 0x00010A74 File Offset: 0x0000EC74
		public GuiScaler(global::VRGIN.Visuals.GUIQuad gui, global::UnityEngine.Transform left, global::UnityEngine.Transform right)
		{
			this._Gui = gui;
			this._Left = left;
			this._Right = right;
			this._StartLeft = new global::UnityEngine.Vector3?(left.position);
			this._StartRight = new global::UnityEngine.Vector3?(right.position);
			this._StartScale = new global::UnityEngine.Vector3?(this._Gui.transform.localScale);
			this._StartRotation = new global::UnityEngine.Quaternion?(this._Gui.transform.localRotation);
			this._StartPosition = new global::UnityEngine.Vector3?(this._Gui.transform.position);
			this._StartRotationController = this.GetAverageRotation();
			float num = global::UnityEngine.Vector3.Distance(this._StartLeft.Value, this._StartRight.Value);
			global::UnityEngine.Vector3 vector = this._StartRight.Value - this._StartLeft.Value;
			global::UnityEngine.Vector3 vector2 = this._StartLeft.Value + vector * 0.5f;
			this._OffsetFromCenter = new global::UnityEngine.Vector3?(this._Gui.transform.position - vector2);
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x00010B94 File Offset: 0x0000ED94
		private global::UnityEngine.Vector3 TopLeft
		{
			get
			{
				return this._Left.position;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x00010BB4 File Offset: 0x0000EDB4
		private global::UnityEngine.Vector3 BottomRight
		{
			get
			{
				return this._Right.position;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060002C7 RID: 711 RVA: 0x00010BD4 File Offset: 0x0000EDD4
		private global::UnityEngine.Vector3 Center
		{
			get
			{
				return global::UnityEngine.Vector3.Lerp(this.TopLeft, this.BottomRight, 0.5f);
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x00010BFC File Offset: 0x0000EDFC
		private global::UnityEngine.Vector3 Up
		{
			get
			{
				return global::UnityEngine.Vector3.Lerp((global::VRGIN.Core.VR.Camera.Head.position - this.TopLeft).normalized, (global::VRGIN.Core.VR.Camera.Head.position - this.BottomRight).normalized, 0.5f);
			}
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x00010C5C File Offset: 0x0000EE5C
		public void Update()
		{
			bool flag = !this._Left || !this._Right;
			if (!flag)
			{
				float num = global::UnityEngine.Vector3.Distance(this._Left.position, this._Right.position);
				float num2 = global::UnityEngine.Vector3.Distance(this._StartLeft.Value, this._StartRight.Value);
				global::UnityEngine.Vector3 vector = this._Right.position - this._Left.position;
				global::UnityEngine.Vector3 vector2 = this._Left.position + vector * 0.5f;
				global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.Inverse(global::VRGIN.Core.VR.Camera.SteamCam.origin.rotation);
				global::UnityEngine.Quaternion averageRotation = this.GetAverageRotation();
				global::UnityEngine.Quaternion quaternion2 = quaternion * averageRotation * global::UnityEngine.Quaternion.Inverse(quaternion * this._StartRotationController);
				this._Gui.transform.localScale = num / num2 * this._StartScale.Value;
				this._Gui.transform.localRotation = quaternion2 * this._StartRotation.Value;
				this._Gui.transform.position = vector2 + averageRotation * global::UnityEngine.Quaternion.Inverse(this._StartRotationController) * this._OffsetFromCenter.Value;
			}
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00010DC8 File Offset: 0x0000EFC8
		private global::UnityEngine.Quaternion GetAverageRotation()
		{
			global::UnityEngine.Vector3 normalized = (this._Right.position - this._Left.position).normalized;
			global::UnityEngine.Vector3 vector = global::UnityEngine.Vector3.Lerp(this._Left.forward, this._Right.forward, 0.5f);
			global::UnityEngine.Vector3 normalized2 = global::UnityEngine.Vector3.Cross(normalized, vector).normalized;
			return global::UnityEngine.Quaternion.LookRotation(normalized2, vector);
		}

		// Token: 0x0400054D RID: 1357
		private global::VRGIN.Visuals.GUIQuad _Gui;

		// Token: 0x0400054E RID: 1358
		private global::UnityEngine.Vector3? _StartLeft;

		// Token: 0x0400054F RID: 1359
		private global::UnityEngine.Vector3? _StartRight;

		// Token: 0x04000550 RID: 1360
		private global::UnityEngine.Vector3? _StartScale;

		// Token: 0x04000551 RID: 1361
		private global::UnityEngine.Quaternion? _StartRotation;

		// Token: 0x04000552 RID: 1362
		private global::UnityEngine.Vector3? _StartPosition;

		// Token: 0x04000553 RID: 1363
		private global::UnityEngine.Quaternion _StartRotationController;

		// Token: 0x04000554 RID: 1364
		private global::UnityEngine.Vector3? _OffsetFromCenter;

		// Token: 0x04000555 RID: 1365
		private global::UnityEngine.Transform _Left;

		// Token: 0x04000556 RID: 1366
		private global::UnityEngine.Transform _Right;
	}
}
