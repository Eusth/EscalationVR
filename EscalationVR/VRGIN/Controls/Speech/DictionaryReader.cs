using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using VRGIN.Core;

namespace VRGIN.Controls.Speech
{
	// Token: 0x020000C4 RID: 196
	public class DictionaryReader
	{
		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x000172DC File Offset: 0x000154DC
		// (set) Token: 0x06000485 RID: 1157 RVA: 0x000172E4 File Offset: 0x000154E4
		public global::System.Type BaseType { get; private set; }

		// Token: 0x06000486 RID: 1158 RVA: 0x000172F0 File Offset: 0x000154F0
		public DictionaryReader(global::System.Type type)
		{
			bool flag = global::VRGIN.Controls.Speech.DictionaryReader.IsVoiceCommandType(type);
			if (flag)
			{
				this.BaseType = type;
			}
			else
			{
				this.BaseType = typeof(global::VRGIN.Controls.Speech.VoiceCommand);
				global::VRGIN.Core.VRLog.Error("Invalid VoiceCommand type! {0}", new object[]
				{
					type
				});
			}
			this.BuildCommandDictionary();
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00017358 File Offset: 0x00015558
		public void LoadDictionary(string path)
		{
			bool flag = global::System.IO.File.Exists(path);
			if (flag)
			{
				using (global::System.IO.StreamReader streamReader = new global::System.IO.StreamReader(global::System.IO.File.OpenRead(path), global::System.Text.Encoding.UTF8))
				{
					global::VRGIN.Controls.Speech.VoiceCommand voiceCommand = null;
					while (!streamReader.EndOfStream)
					{
						string text = streamReader.ReadLine().Trim().ToLowerInvariant();
						bool flag2 = global::VRGIN.Controls.Speech.DictionaryReader.IsCommand(text);
						if (flag2)
						{
							bool flag3 = this._Dictionary.TryGetValue(global::VRGIN.Controls.Speech.DictionaryReader.ExtractCommand(text), ref voiceCommand);
							if (flag3)
							{
								voiceCommand.Texts.Clear();
							}
						}
						else
						{
							bool flag4 = voiceCommand != null && text.Length > 0;
							if (flag4)
							{
								voiceCommand.Texts.Add(text);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00017428 File Offset: 0x00015628
		public void SaveDictionary(string path)
		{
			this.EnsurePath(path);
			using (global::System.IO.StreamWriter streamWriter = new global::System.IO.StreamWriter(global::System.IO.File.Open(path, 4), global::System.Text.Encoding.UTF8))
			{
				streamWriter.BaseStream.SetLength(0L);
				foreach (global::System.Reflection.FieldInfo fieldInfo in global::VRGIN.Controls.Speech.DictionaryReader.ExtractCommands(this.BaseType))
				{
					streamWriter.WriteLine("[{0}]", fieldInfo.Name);
					global::VRGIN.Controls.Speech.VoiceCommand voiceCommand = fieldInfo.GetValue(null) as global::VRGIN.Controls.Speech.VoiceCommand;
					bool flag = voiceCommand != null;
					if (flag)
					{
						foreach (string text in voiceCommand.Texts)
						{
							streamWriter.WriteLine(text);
						}
					}
					streamWriter.WriteLine();
				}
			}
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x0001753C File Offset: 0x0001573C
		private void EnsurePath(string path)
		{
			bool flag = !global::System.IO.File.Exists(path);
			if (flag)
			{
				global::System.IO.Directory.CreateDirectory(global::System.IO.Path.GetDirectoryName(path));
			}
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x00017568 File Offset: 0x00015768
		private void BuildCommandDictionary()
		{
			foreach (global::System.Reflection.FieldInfo fieldInfo in global::VRGIN.Controls.Speech.DictionaryReader.ExtractCommands(this.BaseType))
			{
				global::VRGIN.Controls.Speech.VoiceCommand voiceCommand = fieldInfo.GetValue(null) as global::VRGIN.Controls.Speech.VoiceCommand;
				bool flag = voiceCommand != null;
				if (flag)
				{
					this._Dictionary[fieldInfo.Name.ToLowerInvariant()] = voiceCommand;
				}
			}
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x000175E8 File Offset: 0x000157E8
		public static global::System.Collections.Generic.IEnumerable<global::System.Reflection.FieldInfo> ExtractCommands(global::System.Type type)
		{
			return global::System.Linq.Enumerable.Where<global::System.Reflection.FieldInfo>(type.GetFields(88), (global::System.Reflection.FieldInfo field) => global::VRGIN.Controls.Speech.DictionaryReader.IsVoiceCommandType(field.FieldType));
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x00017628 File Offset: 0x00015828
		public static global::System.Collections.Generic.IEnumerable<global::VRGIN.Controls.Speech.VoiceCommand> ExtractCommandObjects(global::System.Type type)
		{
			return global::System.Linq.Enumerable.Where<global::VRGIN.Controls.Speech.VoiceCommand>(global::System.Linq.Enumerable.Select<global::System.Reflection.FieldInfo, global::VRGIN.Controls.Speech.VoiceCommand>(global::VRGIN.Controls.Speech.DictionaryReader.ExtractCommands(type), (global::System.Reflection.FieldInfo t) => t.GetValue(null) as global::VRGIN.Controls.Speech.VoiceCommand), (global::VRGIN.Controls.Speech.VoiceCommand t) => t != null);
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x00017688 File Offset: 0x00015888
		private static bool IsVoiceCommandType(global::System.Type type)
		{
			return typeof(global::VRGIN.Controls.Speech.VoiceCommand).IsAssignableFrom(type);
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x000176AC File Offset: 0x000158AC
		private static bool IsCommand(string line)
		{
			return line.Length > 2 && line.StartsWith("[", 4) && line.EndsWith("]", 4);
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x000176E4 File Offset: 0x000158E4
		private static string ExtractCommand(string line)
		{
			return line.Substring(1, line.Length - 2);
		}

		// Token: 0x04000627 RID: 1575
		private global::System.Collections.Generic.Dictionary<string, global::VRGIN.Controls.Speech.VoiceCommand> _Dictionary = new global::System.Collections.Generic.Dictionary<string, global::VRGIN.Controls.Speech.VoiceCommand>();
	}
}
