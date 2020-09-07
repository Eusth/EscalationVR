using System;
using System.Linq;
using VRGIN.Core;
using VRGIN.Helpers;

namespace VRGIN.Controls
{
	// Token: 0x020000BC RID: 188
	public class KeyboardShortcut : global::VRGIN.Controls.IShortcut, global::System.IDisposable
	{
		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x000154C7 File Offset: 0x000136C7
		// (set) Token: 0x06000434 RID: 1076 RVA: 0x000154CF File Offset: 0x000136CF
		public global::VRGIN.Helpers.KeyStroke KeyStroke { get; private set; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x000154D8 File Offset: 0x000136D8
		// (set) Token: 0x06000436 RID: 1078 RVA: 0x000154E0 File Offset: 0x000136E0
		public global::System.Action Action { get; private set; }

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x000154E9 File Offset: 0x000136E9
		// (set) Token: 0x06000438 RID: 1080 RVA: 0x000154F1 File Offset: 0x000136F1
		public global::VRGIN.Helpers.KeyMode CheckMode { get; private set; }

		// Token: 0x06000439 RID: 1081 RVA: 0x000154FA File Offset: 0x000136FA
		public KeyboardShortcut(global::VRGIN.Helpers.KeyStroke keyStroke, global::System.Action action, global::VRGIN.Helpers.KeyMode checkMode = global::VRGIN.Helpers.KeyMode.PressUp)
		{
			this.KeyStroke = keyStroke;
			this.Action = action;
			this.CheckMode = checkMode;
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x0001551C File Offset: 0x0001371C
		public KeyboardShortcut(global::VRGIN.Core.XmlKeyStroke keyStroke, global::System.Action action)
		{
			this.KeyStroke = global::System.Linq.Enumerable.FirstOrDefault<global::VRGIN.Helpers.KeyStroke>(keyStroke.GetKeyStrokes());
			this.Action = action;
			this.CheckMode = keyStroke.CheckMode;
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00015550 File Offset: 0x00013750
		public void Evaluate()
		{
			bool flag = this.KeyStroke.Check(this.CheckMode);
			if (flag)
			{
				this.Action.Invoke();
			}
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x00015581 File Offset: 0x00013781
		public void Dispose()
		{
		}
	}
}
