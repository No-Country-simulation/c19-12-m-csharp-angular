namespace backnc.Data.POCOEntities
{
    public class Story
    {
        public int Id { get; set; }
        public int StoryListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public StoryList StoryList { get; set; }
    }
}
