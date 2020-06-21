using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace OnlineStore.Entities
{
    public class Client : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        //The field is not stored in DB
        [NotMapped]
        public string Name =>
            !string.IsNullOrEmpty(this.MiddleName)
                ? this.LastName + " " + this.FirstName + " " + this.MiddleName
                : this.LastName + " " + this.FirstName;

        //Client has orders, relationship 1 to many
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }

        public Client(string firstName, string lastName, string middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }

        //For EF Core
        public Client()
        {

        }
    }
}
