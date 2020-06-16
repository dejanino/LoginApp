﻿using LoginApplication.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApplication
{
    class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int roleId { get; set; }
        public int AddressId { get; set; }
        [JsonIgnore]
        public IList<User> AllUsers { get; set; }

        private const string _path = @"C:\Users\dejan.grozdanovic\Desktop\II SEMESTAR\Class_13\LoginApp\Data\users.json";

        public User()
        {
            
        }
        public User(int _id, string _name, string _email, int _roleId, int _addressId)
        {
            this.ID = _id;
            this.Name = _name;
            this.Email = _email;
            this.roleId = _roleId;
            this.AddressId = _addressId;
        }


        public int SaveUser(string _name, string _email, int _roleId, int _addressId)
        {
            var list = new List<User>();
            if (File.Exists(_path))
            {
                string json = File.ReadAllText(_path);
                list = JsonConvert.DeserializeObject<List<User>>(json);
            }

            try
            {
                int id = list.Count > 0 ? list.LastOrDefault().ID + 1 : 1;
                var user = new User(id, _name, _email, _roleId, _addressId);

                list.Add(user);

                string serializedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(_path, serializedJson);

                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool DeleteUser(int id)
        {
            var list = new List<User>();
            if (File.Exists(_path))
            {
                string json = File.ReadAllText(_path);
                list = JsonConvert.DeserializeObject<List<User>>(json);
            }

            try
            {
                var index = list.FindIndex(x => x.ID == id);
                list.RemoveAt(index);

                string serializedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(_path, serializedJson);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditUser(int id, User user)
        {
            var list = new List<User>();
            if (File.Exists(_path))
            {
                string json = File.ReadAllText(_path);
                list = JsonConvert.DeserializeObject<List<User>>(json);
            }

            try
            {
                var index = list.FindIndex(x => x.ID == id);
                list.RemoveAt(index);
                list.Insert(index, user);

                string serializedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(_path, serializedJson);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public User GetUser(int userId)
        {
            if (AllUsers == null) _getAllUsers();
            var user = AllUsers.Where(x => x.ID == userId).FirstOrDefault();
            return user;
        }

        public IList<User> GetUserList(string name = "")
        {
            if (AllUsers == null) _getAllUsers();
            return AllUsers.Where(x => x.Name.ToLower().Contains(name)).ToList();
        }

        private void _getAllUsers()
        {
            using (StreamReader file = File.OpenText(_path))
            {
                JsonSerializer serializer = new JsonSerializer();
                var list = (List<User>)serializer.Deserialize(file, typeof(List<User>));
                AllUsers = list;

            }
        }
    }
}
