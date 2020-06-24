public interface IEdible
{
    float Nutrition { get; }

    void FeedTo(IEater creature);
}
