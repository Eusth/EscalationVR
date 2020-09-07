using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;

namespace VRGIN.Helpers
{
	// Token: 0x020000D8 RID: 216
	public class KeyStroke
	{
		// Token: 0x0600056F RID: 1391 RVA: 0x0001B004 File Offset: 0x00019204
		public KeyStroke(string strokeString)
		{
			global::UnityEngine.KeyCode[] array = new global::UnityEngine.KeyCode[6];
			global::System.Runtime.CompilerServices.RuntimeHelpers.InitializeArray(array, fieldof(global::<PrivateImplementationDetails>.56E00AE3E24862A05A678D8C8EBB5D992682FA8C44DE1DE046381F424BF15C1C).FieldHandle);
			this.MODIFIER_LIST = array;
			base..ctor();
			string[] array2 = global::System.Linq.Enumerable.ToArray<string>(global::System.Linq.Enumerable.Select<string, string>(strokeString.ToUpper().Split(new char[]
			{
				'+',
				'-'
			}), (string key) => key.Trim()));
			int i = 0;
			while (i < array2.Length)
			{
				string text = array2[i];
				string text2 = text;
				string text3 = text2;
				if (text3 == null)
				{
					goto IL_E8;
				}
				if (!(text3 == "CTRL"))
				{
					if (!(text3 == "ALT"))
					{
						if (!(text3 == "SHIFT"))
						{
							goto IL_E8;
						}
						this.AddStroke(304);
					}
					else
					{
						this.AddStroke(308);
					}
				}
				else
				{
					this.AddStroke(306);
				}
				IL_15B:
				i++;
				continue;
				IL_E8:
				try
				{
					bool flag = global::System.Text.RegularExpressions.Regex.IsMatch(text, "^\\d$");
					if (flag)
					{
						text = "Alpha" + text;
					}
					bool flag2 = global::System.Text.RegularExpressions.Regex.IsMatch(text, "^(LEFT|RIGHT|UP|DOWN)$");
					if (flag2)
					{
						text += "ARROW";
					}
					this.AddStroke((global::UnityEngine.KeyCode)global::System.Enum.Parse(typeof(global::UnityEngine.KeyCode), text, true));
				}
				catch (global::System.Exception)
				{
					global::System.Console.WriteLine("FAILED TO PARSE KEY \"{0}\"", text);
				}
				goto IL_15B;
			}
			this.Init();
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x0001B198 File Offset: 0x00019398
		public KeyStroke(global::System.Collections.Generic.IEnumerable<global::UnityEngine.KeyCode> strokes)
		{
			global::UnityEngine.KeyCode[] array = new global::UnityEngine.KeyCode[6];
			global::System.Runtime.CompilerServices.RuntimeHelpers.InitializeArray(array, fieldof(global::<PrivateImplementationDetails>.56E00AE3E24862A05A678D8C8EBB5D992682FA8C44DE1DE046381F424BF15C1C).FieldHandle);
			this.MODIFIER_LIST = array;
			base..ctor();
			foreach (global::UnityEngine.KeyCode stroke in strokes)
			{
				this.AddStroke(stroke);
			}
			this.Init();
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x0001B220 File Offset: 0x00019420
		private void Init()
		{
			bool flag = this.modifiers.Count > 0 && this.keys.Count == 0;
			if (flag)
			{
				this.keys.AddRange(this.modifiers);
				this.modifiers.Clear();
			}
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x0001B274 File Offset: 0x00019474
		private void AddStroke(global::UnityEngine.KeyCode stroke)
		{
			bool flag = global::System.Linq.Enumerable.Contains<global::UnityEngine.KeyCode>(this.MODIFIER_LIST, stroke);
			if (flag)
			{
				this.modifiers.Add(stroke);
			}
			else
			{
				this.keys.Add(stroke);
			}
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x0001B2B0 File Offset: 0x000194B0
		public bool Check(global::VRGIN.Helpers.KeyMode mode = global::VRGIN.Helpers.KeyMode.PressDown)
		{
			bool flag = this.modifiers.Count == 0 && this.keys.Count == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2;
				if (global::System.Linq.Enumerable.All<global::UnityEngine.KeyCode>(this.modifiers, (global::UnityEngine.KeyCode key) => global::UnityEngine.Input.GetKey(key)) && global::System.Linq.Enumerable.All<global::UnityEngine.KeyCode>(this.keys, (global::UnityEngine.KeyCode key) => (mode == global::VRGIN.Helpers.KeyMode.Press) ? global::UnityEngine.Input.GetKey(key) : ((mode == global::VRGIN.Helpers.KeyMode.PressDown) ? global::UnityEngine.Input.GetKeyDown(key) : global::UnityEngine.Input.GetKeyUp(key))))
				{
					flag2 = global::System.Linq.Enumerable.All<global::UnityEngine.KeyCode>(global::System.Linq.Enumerable.Except<global::UnityEngine.KeyCode>(this.MODIFIER_LIST, this.modifiers), (global::UnityEngine.KeyCode invalidModifier) => !global::UnityEngine.Input.GetKey(invalidModifier));
				}
				else
				{
					flag2 = false;
				}
				result = flag2;
			}
			return result;
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x0001B378 File Offset: 0x00019578
		public override string ToString()
		{
			return string.Join("+", global::System.Linq.Enumerable.ToArray<string>(global::System.Linq.Enumerable.Union<string>(global::System.Linq.Enumerable.Select<global::UnityEngine.KeyCode, string>(this.modifiers, (global::UnityEngine.KeyCode m) => m.ToString()), global::System.Linq.Enumerable.Select<global::UnityEngine.KeyCode, string>(this.keys, (global::UnityEngine.KeyCode k) => k.ToString()))));
		}

		// Token: 0x04000665 RID: 1637
		private global::System.Collections.Generic.List<global::UnityEngine.KeyCode> modifiers = new global::System.Collections.Generic.List<global::UnityEngine.KeyCode>();

		// Token: 0x04000666 RID: 1638
		private global::System.Collections.Generic.List<global::UnityEngine.KeyCode> keys = new global::System.Collections.Generic.List<global::UnityEngine.KeyCode>();

		// Token: 0x04000667 RID: 1639
		private global::UnityEngine.KeyCode[] MODIFIER_LIST;
	}
}
