using MongoDB.Driver;
using Entities.Data;
using Entities.Models;

namespace Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _user;
        public UserService(IUserDatabaseSettings settings, IMongoClient mongoClient)
        {
          
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _user = database.GetCollection<User>(settings.UserCollectionName);
          
         }
        public User Create(User usr)
        {
            _user.InsertOne(usr);
            return usr;
        }
        public List<User> Get()
        {
            List<User> user;
            var x = _user.Find(usr => true).ToList();
            user = _user.Find(usr => true).ToList();
            return user;
        }
        public User Get(string id) =>
            _user.Find<User>(usr => usr._id  == id).FirstOrDefault();
        public User ExistsUser(int id) =>
           _user.Find<User>(usr => usr.Id == id).FirstOrDefault();

        public void Remove(string id)
        {
            _user.DeleteOne(usr => usr._id == id);
        }

        public void Update(string id, User Usr)
        {
            _user.ReplaceOne(usr => usr._id == id, Usr);
        }
    }
}
