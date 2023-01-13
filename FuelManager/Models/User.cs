namespace FuelManager.Models
{
    public class User
    {
        public User()
        {
            Cars = new List<Car>();

        }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }

        public virtual List<Car> Cars { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }

    }
}
