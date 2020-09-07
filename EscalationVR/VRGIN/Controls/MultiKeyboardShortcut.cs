using System;
using UnityEngine;
using VRGIN.Core;
using VRGIN.Helpers;

namespace VRGIN.Controls
{
	// Token: 0x020000BD RID: 189
	public class MultiKeyboardShortcut : global::VRGIN.Controls.IShortcut, global::System.IDisposable
	{
		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x00015584 File Offset: 0x00013784
		// (set) Token: 0x0600043E RID: 1086 RVA: 0x0001558C File Offset: 0x0001378C
		public global::VRGIN.Helpers.KeyStroke[] KeyStrokes { get; private set; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x00015595 File Offset: 0x00013795
		// (set) Token: 0x06000440 RID: 1088 RVA: 0x0001559D File Offset: 0x0001379D
		public global::System.Action Action { get; private set; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x000155A6 File Offset: 0x000137A6
		// (set) Token: 0x06000442 RID: 1090 RVA: 0x000155AE File Offset: 0x000137AE
		public global::VRGIN.Helpers.KeyMode CheckMode { get; private set; }

		// Token: 0x06000443 RID: 1091 RVA: 0x000155B7 File Offset: 0x000137B7
		public MultiKeyboardShortcut(global::VRGIN.Helpers.KeyStroke[] keyStrokes, global::System.Action action, global::VRGIN.Helpers.KeyMode checkMode = global::VRGIN.Helpers.KeyMode.PressUp)
		{
			this.KeyStrokes = keyStrokes;
			this.Action = action;
			this.CheckMode = checkMode;
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x000155EC File Offset: 0x000137EC
		public MultiKeyboardShortcut(global::VRGIN.Helpers.KeyStroke keyStroke1, global::VRGIN.Helpers.KeyStroke keyStroke2, global::System.Action action, global::VRGIN.Helpers.KeyMode checkMode = global::VRGIN.Helpers.KeyMode.PressUp)
		{
			this.KeyStrokes = new global::VRGIN.Helpers.KeyStroke[]
			{
				keyStroke1,
				keyStroke2
			};
			this.Action = action;
			this.CheckMode = checkMode;
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00015639 File Offset: 0x00013839
		public MultiKeyboardShortcut(global::VRGIN.Core.XmlKeyStroke stroke, global::System.Action action)
		{
			this.KeyStrokes = stroke.GetKeyStrokes();
			this.Action = action;
			this.CheckMode = stroke.CheckMode;
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00015678 File Offset: 0x00013878
		public void Evaluate()
		{
			bool flag = global::UnityEngine.Time.time - this._Time > 0.5f;
			if (flag)
			{
				this._Index = 0;
			}
			bool flag2 = this._Index == this.KeyStrokes.Length - 1;
			global::VRGIN.Helpers.KeyMode mode = flag2 ? this.CheckMode : global::VRGIN.Helpers.KeyMode.PressUp;
			bool flag3 = this.KeyStrokes[this._Index].Check(mode);
			if (flag3)
			{
				bool flag4 = flag2;
				if (flag4)
				{
					this.Action.Invoke();
				}
				else
				{
					this._Index++;
					this._Time = global::UnityEngine.Time.unscaledTime;
				}
			}
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00015711 File Offset: 0x00013911
		public void Dispose()
		{
		}

		// Token: 0x040005F6 RID: 1526
		private const float WAIT_TIME = 0.5f;

		// Token: 0x040005FA RID: 1530
		private int _Index = 0;

		// Token: 0x040005FB RID: 1531
		private float _Time = 0f;
	}
}
