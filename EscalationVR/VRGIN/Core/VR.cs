using System;
using VRGIN.Controls.Speech;
using VRGIN.Modes;
using WindowsInput;

namespace VRGIN.Core
{
	// Token: 0x020000B0 RID: 176
	public static class VR
	{
		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x00013364 File Offset: 0x00011564
		public static global::VRGIN.Core.GameInterpreter Interpreter
		{
			get
			{
				return global::VRGIN.Core.VRManager.Instance.Interpreter;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x00013380 File Offset: 0x00011580
		public static global::VRGIN.Core.VRCamera Camera
		{
			get
			{
				return global::VRGIN.Core.VRCamera.Instance;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060003A6 RID: 934 RVA: 0x00013398 File Offset: 0x00011598
		public static global::VRGIN.Core.VRGUI GUI
		{
			get
			{
				return global::VRGIN.Core.VRGUI.Instance;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060003A7 RID: 935 RVA: 0x000133B0 File Offset: 0x000115B0
		public static global::VRGIN.Core.IVRManagerContext Context
		{
			get
			{
				return global::VRGIN.Core.VRManager.Instance.Context;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060003A8 RID: 936 RVA: 0x000133CC File Offset: 0x000115CC
		public static global::VRGIN.Modes.ControlMode Mode
		{
			get
			{
				return global::VRGIN.Core.VRManager.Instance.Mode;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060003A9 RID: 937 RVA: 0x000133E8 File Offset: 0x000115E8
		public static global::VRGIN.Core.VRSettings Settings
		{
			get
			{
				return global::VRGIN.Core.VR.Context.Settings;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060003AA RID: 938 RVA: 0x00013404 File Offset: 0x00011604
		public static global::VRGIN.Core.Shortcuts Shortcuts
		{
			get
			{
				return global::VRGIN.Core.VR.Context.Settings.Shortcuts;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060003AB RID: 939 RVA: 0x00013428 File Offset: 0x00011628
		public static global::VRGIN.Core.VRManager Manager
		{
			get
			{
				return global::VRGIN.Core.VRManager.Instance;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060003AC RID: 940 RVA: 0x00013440 File Offset: 0x00011640
		public static global::WindowsInput.InputSimulator Input
		{
			get
			{
				return global::VRGIN.Core.VRManager.Instance.Input;
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060003AD RID: 941 RVA: 0x0001345C File Offset: 0x0001165C
		public static global::VRGIN.Controls.Speech.SpeechManager Speech
		{
			get
			{
				return global::VRGIN.Core.VRManager.Instance.Speech;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060003AE RID: 942 RVA: 0x00013478 File Offset: 0x00011678
		public static global::VRGIN.Core.HMDType HMD
		{
			get
			{
				return global::VRGIN.Core.VRManager.Instance.HMD;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060003AF RID: 943 RVA: 0x00013494 File Offset: 0x00011694
		// (set) Token: 0x060003B0 RID: 944 RVA: 0x0001349B File Offset: 0x0001169B
		public static bool Active { get; set; }
	}
}
