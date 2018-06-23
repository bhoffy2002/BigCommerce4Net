namespace BigCommerce4Net.Api.V3
{
	public interface IParentEntityGetUpdateDelete<T> : IParentEntityGetUpdate<T>
	{
		IClientResponse<bool> Delete(int id);

	}

	public abstract class ParentEntityGetUpdateDelete<T> : ParentEntityGetUpdate<T>, IParentEntityGetUpdateDelete<T>
		where T : new()
	{
		protected ParentEntityGetUpdateDelete(Configuration configuration) : base(configuration)
		{
		}

		public IClientResponse<bool> Delete(int id)
		{
			var results = DeleteData(string.Format(base.resourceEndpoint_id, id));
			return results;
		}
	}
}