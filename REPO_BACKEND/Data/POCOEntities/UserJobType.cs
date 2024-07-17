namespace backnc.Data.POCOEntities
{
    public class UserJobType
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int JobTypeId { get; set; }

        public User User { get; set; }
        public JobType JobType { get; set; }
        public ICollection<StoryList> StoryLists { get; set; }
    }
}
