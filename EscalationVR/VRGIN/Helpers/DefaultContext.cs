using System;
using UnityEngine;
using VRGIN.Controls.Speech;
using VRGIN.Core;
using VRGIN.Visuals;

namespace VRGIN.Helpers
{
	// Token: 0x020000D5 RID: 213
	public class DefaultContext : global::VRGIN.Core.IVRManagerContext
	{
		// Token: 0x06000549 RID: 1353 RVA: 0x0001AA90 File Offset: 0x00018C90
		public DefaultContext()
		{
			this._Materials = this.CreateMaterialPalette();
			this._Settings = this.CreateSettings();
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x0001AAB4 File Offset: 0x00018CB4
		protected virtual global::VRGIN.Visuals.IMaterialPalette CreateMaterialPalette()
		{
			return new global::VRGIN.Visuals.DefaultMaterialPalette();
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x0001AACC File Offset: 0x00018CCC
		protected virtual global::VRGIN.Core.VRSettings CreateSettings()
		{
			return global::VRGIN.Core.VRSettings.Load<global::VRGIN.Core.VRSettings>("VRSettings.xml");
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600054C RID: 1356 RVA: 0x0001AAE8 File Offset: 0x00018CE8
		public virtual bool ConfineMouse
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x0600054D RID: 1357 RVA: 0x0001AAFC File Offset: 0x00018CFC
		public virtual bool EnforceDefaultGUIMaterials
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600054E RID: 1358 RVA: 0x0001AB10 File Offset: 0x00018D10
		public virtual bool GUIAlternativeSortingMode
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600054F RID: 1359 RVA: 0x0001AB24 File Offset: 0x00018D24
		public virtual float GuiFarClipPlane
		{
			get
			{
				return 10000f;
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000550 RID: 1360 RVA: 0x0001AB3C File Offset: 0x00018D3C
		public virtual string GuiLayer
		{
			get
			{
				return "Default";
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000551 RID: 1361 RVA: 0x0001AB54 File Offset: 0x00018D54
		public virtual float GuiNearClipPlane
		{
			get
			{
				return -10000f;
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000552 RID: 1362 RVA: 0x0001AB6C File Offset: 0x00018D6C
		public virtual int IgnoreMask
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000553 RID: 1363 RVA: 0x0001AB80 File Offset: 0x00018D80
		public virtual string InvisibleLayer
		{
			get
			{
				return "Ignore Raycast";
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000554 RID: 1364 RVA: 0x0001AB98 File Offset: 0x00018D98
		public global::VRGIN.Visuals.IMaterialPalette Materials
		{
			get
			{
				return this._Materials;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000555 RID: 1365 RVA: 0x0001ABB0 File Offset: 0x00018DB0
		public virtual float NearClipPlane
		{
			get
			{
				return 0.1f;
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000556 RID: 1366 RVA: 0x0001ABC8 File Offset: 0x00018DC8
		public virtual global::VRGIN.Core.GUIType PreferredGUI
		{
			get
			{
				return global::VRGIN.Core.GUIType.uGUI;
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000557 RID: 1367 RVA: 0x0001ABDC File Offset: 0x00018DDC
		public virtual global::UnityEngine.Color PrimaryColor
		{
			get
			{
				return global::UnityEngine.Color.cyan;
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000558 RID: 1368 RVA: 0x0001ABF4 File Offset: 0x00018DF4
		public virtual global::VRGIN.Core.VRSettings Settings
		{
			get
			{
				return this._Settings;
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000559 RID: 1369 RVA: 0x0001AC0C File Offset: 0x00018E0C
		public virtual bool SimulateCursor
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x0600055A RID: 1370 RVA: 0x0001AC20 File Offset: 0x00018E20
		public virtual string UILayer
		{
			get
			{
				return "UI";
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x0600055B RID: 1371 RVA: 0x0001AC38 File Offset: 0x00018E38
		public virtual int UILayerMask
		{
			get
			{
				return global::UnityEngine.LayerMask.GetMask(new string[]
				{
					this.UILayer
				});
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x0600055C RID: 1372 RVA: 0x0001AC60 File Offset: 0x00018E60
		public virtual float UnitToMeter
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x0600055D RID: 1373 RVA: 0x0001AC78 File Offset: 0x00018E78
		public virtual global::System.Type VoiceCommandType
		{
			get
			{
				return typeof(global::VRGIN.Controls.Speech.VoiceCommand);
			}
		}

		// Token: 0x0400065F RID: 1631
		private global::VRGIN.Visuals.IMaterialPalette _Materials;

		// Token: 0x04000660 RID: 1632
		private global::VRGIN.Core.VRSettings _Settings;
	}
}
