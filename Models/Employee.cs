using System;

namespace CoreApi.Models {
    public class Employee: Entity<long> {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}