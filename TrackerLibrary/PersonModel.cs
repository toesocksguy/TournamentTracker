using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class PersonModel
    {
        /// <summary>
        /// Represents this person's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Represents this person's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Represents this person's email address
        /// </summary>
        public string EmailAddress { get; set; }
        
        
        /// <summary>
        /// Represents this person's cellphone number
        /// </summary>
        public string CellphoneNumber { get; set; }
    }
}
