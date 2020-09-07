using System;
using UnityEngine;
using VRGIN.Core;
using VRGIN.Helpers;

namespace VRGIN.Visuals
{
	// Token: 0x02000088 RID: 136
	public class DefaultMaterialPalette : global::VRGIN.Visuals.IMaterialPalette
	{
		// Token: 0x06000215 RID: 533 RVA: 0x0000D9D0 File Offset: 0x0000BBD0
		public DefaultMaterialPalette()
		{
			this.Unlit = this.CreateUnlit();
			this.UnlitTransparent = this.CreateUnlitTransparent();
			this.UnlitTransparentCombined = this.CreateUnlitTransparentCombined();
			this.StandardShader = this.CreateStandardShader();
			this.Sprite = this.CreateSprite();
			bool flag = !this.Unlit || !this.Unlit.shader;
			if (flag)
			{
				global::VRGIN.Core.VRLog.Error("Could not load Unlit material!", global::System.Array.Empty<object>());
			}
			bool flag2 = !this.UnlitTransparent || !this.UnlitTransparent.shader;
			if (flag2)
			{
				global::VRGIN.Core.VRLog.Error("Could not load UnlitTransparent material!", global::System.Array.Empty<object>());
			}
			bool flag3 = !this.UnlitTransparentCombined || !this.UnlitTransparentCombined.shader;
			if (flag3)
			{
				global::VRGIN.Core.VRLog.Error("Could not load UnlitTransparentCombined material!", global::System.Array.Empty<object>());
			}
			bool flag4 = !this.StandardShader;
			if (flag4)
			{
				global::VRGIN.Core.VRLog.Error("Could not load StandardShader material!", global::System.Array.Empty<object>());
			}
			bool flag5 = !this.Sprite || !this.Sprite.shader;
			if (flag5)
			{
				global::VRGIN.Core.VRLog.Error("Could not load Sprite material!", global::System.Array.Empty<object>());
				this.Sprite = this.UnlitTransparent;
			}
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0000DB38 File Offset: 0x0000BD38
		private global::UnityEngine.Material CreateUnlitTransparentCombined()
		{
			return new global::UnityEngine.Material(global::VRGIN.Helpers.UnityHelper.GetShader("UnlitTransparentCombined"));
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000217 RID: 535 RVA: 0x0000DB59 File Offset: 0x0000BD59
		// (set) Token: 0x06000218 RID: 536 RVA: 0x0000DB61 File Offset: 0x0000BD61
		public global::UnityEngine.Material UnlitTransparentCombined { get; set; }

		// Token: 0x06000219 RID: 537 RVA: 0x0000DB6C File Offset: 0x0000BD6C
		private global::UnityEngine.Material CreateSprite()
		{
			return global::UnityEngine.Resources.GetBuiltinResource<global::UnityEngine.Material>("Sprites-Default.mat");
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600021A RID: 538 RVA: 0x0000DB88 File Offset: 0x0000BD88
		// (set) Token: 0x0600021B RID: 539 RVA: 0x0000DB90 File Offset: 0x0000BD90
		public global::UnityEngine.Material Sprite { get; set; }

		// Token: 0x0600021C RID: 540 RVA: 0x0000DB9C File Offset: 0x0000BD9C
		private global::UnityEngine.Shader CreateStandardShader()
		{
			return global::UnityEngine.Shader.Find("Standard");
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600021D RID: 541 RVA: 0x0000DBB8 File Offset: 0x0000BDB8
		// (set) Token: 0x0600021E RID: 542 RVA: 0x0000DBC0 File Offset: 0x0000BDC0
		public global::UnityEngine.Shader StandardShader { get; set; }

		// Token: 0x0600021F RID: 543 RVA: 0x0000DBCC File Offset: 0x0000BDCC
		private global::UnityEngine.Material CreateUnlit()
		{
			return new global::UnityEngine.Material(global::VRGIN.Helpers.UnityHelper.GetShader("Unlit"));
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000220 RID: 544 RVA: 0x0000DBED File Offset: 0x0000BDED
		// (set) Token: 0x06000221 RID: 545 RVA: 0x0000DBF5 File Offset: 0x0000BDF5
		public global::UnityEngine.Material Unlit { get; set; }

		// Token: 0x06000222 RID: 546 RVA: 0x0000DC00 File Offset: 0x0000BE00
		private global::UnityEngine.Material CreateUnlitTransparent()
		{
			return new global::UnityEngine.Material(global::VRGIN.Helpers.UnityHelper.GetShader("UnlitTransparent"));
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000223 RID: 547 RVA: 0x0000DC21 File Offset: 0x0000BE21
		// (set) Token: 0x06000224 RID: 548 RVA: 0x0000DC29 File Offset: 0x0000BE29
		public global::UnityEngine.Material UnlitTransparent { get; set; }
	}
}
