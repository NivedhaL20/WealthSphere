
namespace WealthSphere.Model
{
    public class FeedbackModel
    {
        public Guid Id { get; set; }
        public string ?VisuallyAppealing { get; set; }
        public string ?EasyToAccess { get; set; }
        public string ?AnyChangesRequired { get; set; }
        public string ?MostLikedFeature { get; set; }
        public string ?Rating { get; set; }
        public string ?UserId { get; set; }
    }
}
