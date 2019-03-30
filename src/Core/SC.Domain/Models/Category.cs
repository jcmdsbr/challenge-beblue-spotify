namespace SC.Domain.Models {
    public class Category {
        public int Id { get; private set; }
        public string Description { get; private set; }

        protected Category () {

        }
        public Category (int id, string description) {
            this.Id = id;
            this.Description = description;
        }
    }
}