using System;
using UnityEngine;
using VRGIN.Core;
using VRGIN.Helpers;

namespace VRGIN.Visuals
{
	// Token: 0x0200008F RID: 143
	public class SimulatedCursor : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x06000251 RID: 593 RVA: 0x0000EE04 File Offset: 0x0000D004
		public static global::VRGIN.Visuals.SimulatedCursor Create()
		{
			return new global::UnityEngine.GameObject("VRGIN_Cursor").AddComponent<global::VRGIN.Visuals.SimulatedCursor>();
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000EE28 File Offset: 0x0000D028
		protected override void OnAwake()
		{
			base.OnAwake();
			this._DefaultSprite = global::VRGIN.Helpers.UnityHelper.LoadImage("cursor.png");
			this._Scale = new global::UnityEngine.Vector2((float)this._DefaultSprite.width, (float)this._DefaultSprite.height) * 0.5f;
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000EE7A File Offset: 0x0000D07A
		protected override void OnStart()
		{
			base.OnStart();
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000EE84 File Offset: 0x0000D084
		private void OnGUI()
		{
			global::UnityEngine.GUI.depth = -2147483647;
			bool visible = global::UnityEngine.Cursor.visible;
			if (visible)
			{
				global::UnityEngine.Vector2 vector;
				vector..ctor(global::UnityEngine.Input.mousePosition.x, (float)global::UnityEngine.Screen.height - global::UnityEngine.Input.mousePosition.y);
				global::UnityEngine.GUI.DrawTexture(new global::UnityEngine.Rect(vector.x, vector.y, this._Scale.x, this._Scale.y), this._Sprite ?? this._DefaultSprite);
			}
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000EF07 File Offset: 0x0000D107
		public void SetCursor(global::UnityEngine.Texture2D texture)
		{
			this._Sprite = texture;
		}

		// Token: 0x04000533 RID: 1331
		private global::UnityEngine.Texture2D _Sprite;

		// Token: 0x04000534 RID: 1332
		private global::UnityEngine.Texture2D _DefaultSprite;

		// Token: 0x04000535 RID: 1333
		private global::UnityEngine.Vector2 _Scale;
	}
}
