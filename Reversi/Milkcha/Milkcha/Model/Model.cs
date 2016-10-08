using Milkcha.Model;

namespace MilkCha.Model
{
    public class Model : BindableBase
    {
		int result;

		public int Result
		{
			get
			{
				return result;
			}

			set
			{
				SetProperty(ref result, value);
			}
		}
	}
}
