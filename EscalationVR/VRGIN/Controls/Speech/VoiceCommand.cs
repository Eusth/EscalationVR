using System;
using System.Collections.Generic;
using System.Linq;

namespace VRGIN.Controls.Speech
{
	// Token: 0x020000C7 RID: 199
	public class VoiceCommand
	{
		// Token: 0x0600049F RID: 1183 RVA: 0x00017C55 File Offset: 0x00015E55
		protected VoiceCommand(params string[] texts)
		{
			this.Texts = global::System.Linq.Enumerable.ToList<string>(texts);
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00017C6C File Offset: 0x00015E6C
		public bool Matches(string text)
		{
			return this.Texts.Contains(text);
		}

		// Token: 0x04000633 RID: 1587
		public static readonly global::VRGIN.Controls.Speech.VoiceCommand ToggleMenu = new global::VRGIN.Controls.Speech.VoiceCommand(new string[]
		{
			"toggle menu"
		});

		// Token: 0x04000634 RID: 1588
		public static readonly global::VRGIN.Controls.Speech.VoiceCommand Impersonate = new global::VRGIN.Controls.Speech.VoiceCommand(new string[]
		{
			"impersonate"
		});

		// Token: 0x04000635 RID: 1589
		public static readonly global::VRGIN.Controls.Speech.VoiceCommand SaveSettings = new global::VRGIN.Controls.Speech.VoiceCommand(new string[]
		{
			"save settings"
		});

		// Token: 0x04000636 RID: 1590
		public static readonly global::VRGIN.Controls.Speech.VoiceCommand LoadSettings = new global::VRGIN.Controls.Speech.VoiceCommand(new string[]
		{
			"load settings"
		});

		// Token: 0x04000637 RID: 1591
		public static readonly global::VRGIN.Controls.Speech.VoiceCommand ResetSettings = new global::VRGIN.Controls.Speech.VoiceCommand(new string[]
		{
			"reset settings"
		});

		// Token: 0x04000638 RID: 1592
		public static readonly global::VRGIN.Controls.Speech.VoiceCommand IncreaseScale = new global::VRGIN.Controls.Speech.VoiceCommand(new string[]
		{
			"increase scale",
			"larger",
			"bigger"
		});

		// Token: 0x04000639 RID: 1593
		public static readonly global::VRGIN.Controls.Speech.VoiceCommand DecreaseScale = new global::VRGIN.Controls.Speech.VoiceCommand(new string[]
		{
			"decrease scale",
			"smaller"
		});

		// Token: 0x0400063A RID: 1594
		public global::System.Collections.Generic.List<string> Texts;
	}
}
