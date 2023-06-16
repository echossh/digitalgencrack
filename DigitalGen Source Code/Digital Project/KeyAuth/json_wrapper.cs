using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace KeyAuth
{
	// Token: 0x02000004 RID: 4
	public class json_wrapper
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00003844 File Offset: 0x00001A44
		public static bool is_serializable(Type to_check)
		{
			return to_check.IsSerializable || to_check.IsDefined(typeof(DataContractAttribute), true);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003864 File Offset: 0x00001A64
		public json_wrapper(object obj_to_work_with)
		{
			this.current_object = obj_to_work_with;
			Type object_type = this.current_object.GetType();
			this.serializer = new DataContractJsonSerializer(object_type);
			bool flag = !json_wrapper.is_serializable(object_type);
			if (flag)
			{
				throw new Exception(string.Format("the object {0} isn't a serializable", this.current_object));
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000038BC File Offset: 0x00001ABC
		public object string_to_object(string json)
		{
			byte[] buffer = Encoding.Default.GetBytes(json);
			object result;
			using (MemoryStream mem_stream = new MemoryStream(buffer))
			{
				result = this.serializer.ReadObject(mem_stream);
			}
			return result;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003908 File Offset: 0x00001B08
		public T string_to_generic<T>(string json)
		{
			return (!!0)((object)this.string_to_object(json));
		}

		// Token: 0x0400000D RID: 13
		private DataContractJsonSerializer serializer;

		// Token: 0x0400000E RID: 14
		private object current_object;
	}
}
