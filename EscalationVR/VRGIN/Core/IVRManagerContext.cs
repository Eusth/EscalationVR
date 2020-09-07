using System;
using UnityEngine;
using VRGIN.Visuals;

namespace VRGIN.Core
{
	// Token: 0x020000A1 RID: 161
	public interface IVRManagerContext
	{
		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060002F2 RID: 754
		string GuiLayer { get; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060002F3 RID: 755
		string UILayer { get; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060002F4 RID: 756
		int UILayerMask { get; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060002F5 RID: 757
		int IgnoreMask { get; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060002F6 RID: 758
		global::UnityEngine.Color PrimaryColor { get; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060002F7 RID: 759
		global::VRGIN.Visuals.IMaterialPalette Materials { get; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060002F8 RID: 760
		global::VRGIN.Core.VRSettings Settings { get; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060002F9 RID: 761
		string InvisibleLayer { get; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060002FA RID: 762
		bool SimulateCursor { get; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060002FB RID: 763
		bool GUIAlternativeSortingMode { get; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060002FC RID: 764
		global::System.Type VoiceCommandType { get; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060002FD RID: 765
		float GuiNearClipPlane { get; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060002FE RID: 766
		float GuiFarClipPlane { get; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060002FF RID: 767
		float NearClipPlane { get; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000300 RID: 768
		float UnitToMeter { get; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000301 RID: 769
		bool EnforceDefaultGUIMaterials { get; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000302 RID: 770
		bool ConfineMouse { get; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000303 RID: 771
		global::VRGIN.Core.GUIType PreferredGUI { get; }
	}
}
