using System;
using UnityEngine;
using VRGIN.Controls.Speech;
using VRGIN.Core;
using VRGIN.Visuals;

namespace EscalationVR
{
	// Token: 0x020000EA RID: 234
	public class EscalationVRContext : global::VRGIN.Core.IVRManagerContext
	{
		// Token: 0x060005E4 RID: 1508 RVA: 0x0001CF60 File Offset: 0x0001B160
		public EscalationVRContext()
		{
			this._Materials = new global::VRGIN.Visuals.DefaultMaterialPalette();
			this._Settings = global::VRGIN.Core.VRSettings.Load<global::VRGIN.Core.VRSettings>("vr_settings.xml");
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060005E5 RID: 1509 RVA: 0x0001CF9C File Offset: 0x0001B19C
		public bool GUIAlternativeSortingMode
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060005E6 RID: 1510 RVA: 0x0001CFB0 File Offset: 0x0001B1B0
		public float GuiFarClipPlane
		{
			get
			{
				return 10000f;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060005E7 RID: 1511 RVA: 0x0001CFC7 File Offset: 0x0001B1C7
		public float NearClipPlane
		{
			get
			{
				return 0.01f;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060005E8 RID: 1512 RVA: 0x0001CFD0 File Offset: 0x0001B1D0
		public string GuiLayer
		{
			get
			{
				return "Default";
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x060005E9 RID: 1513 RVA: 0x0001CFE8 File Offset: 0x0001B1E8
		public float GuiNearClipPlane
		{
			get
			{
				return 0.1f;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x060005EA RID: 1514 RVA: 0x0001D000 File Offset: 0x0001B200
		public int IgnoreMask
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x060005EB RID: 1515 RVA: 0x0001D014 File Offset: 0x0001B214
		public string InvisibleLayer
		{
			get
			{
				return "Ignore Raycast";
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060005EC RID: 1516 RVA: 0x0001D02C File Offset: 0x0001B22C
		public global::VRGIN.Visuals.IMaterialPalette Materials
		{
			get
			{
				return this._Materials;
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060005ED RID: 1517 RVA: 0x0001D044 File Offset: 0x0001B244
		public global::UnityEngine.Color PrimaryColor
		{
			get
			{
				return global::UnityEngine.Color.cyan;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060005EE RID: 1518 RVA: 0x0001D05C File Offset: 0x0001B25C
		public global::VRGIN.Core.VRSettings Settings
		{
			get
			{
				return this._Settings;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060005EF RID: 1519 RVA: 0x0001D074 File Offset: 0x0001B274
		public bool SimulateCursor
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060005F0 RID: 1520 RVA: 0x0001D088 File Offset: 0x0001B288
		public string UILayer
		{
			get
			{
				return "UI";
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x060005F1 RID: 1521 RVA: 0x0001D0A0 File Offset: 0x0001B2A0
		public int UILayerMask
		{
			get
			{
				return global::UnityEngine.LayerMask.GetMask(new string[]
				{
					this.UILayer
				});
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x060005F2 RID: 1522 RVA: 0x0001D0C8 File Offset: 0x0001B2C8
		public float UnitToMeter
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060005F3 RID: 1523 RVA: 0x0001D0DF File Offset: 0x0001B2DF
		public bool EnforceDefaultGUIMaterials { get; } = 0;

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060005F4 RID: 1524 RVA: 0x0001D0E7 File Offset: 0x0001B2E7
		public bool ConfineMouse { get; } = 1;

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060005F5 RID: 1525 RVA: 0x0001D0EF File Offset: 0x0001B2EF
		public global::VRGIN.Core.GUIType PreferredGUI { get; } = 0;

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x060005F6 RID: 1526 RVA: 0x0001D0F8 File Offset: 0x0001B2F8
		public global::System.Type VoiceCommandType
		{
			get
			{
				return typeof(global::VRGIN.Controls.Speech.VoiceCommand);
			}
		}

		// Token: 0x04000690 RID: 1680
		private global::VRGIN.Visuals.DefaultMaterialPalette _Materials;

		// Token: 0x04000691 RID: 1681
		private global::VRGIN.Core.VRSettings _Settings;
	}
}
