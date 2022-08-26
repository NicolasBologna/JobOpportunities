namespace EndavaCareers.API.Integrations
{
    public interface ISender
    {
        void CreateEntity<T>(T entity) where T : class;
    }
}