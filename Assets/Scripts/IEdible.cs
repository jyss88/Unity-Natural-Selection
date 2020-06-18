public interface IEdible
{
    float Nutrition { get; }

    void FeedTo(CreatureBehaviour creature);
}
