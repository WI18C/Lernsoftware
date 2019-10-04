using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernsoftware
{
    class User
    {
        private int userId;
        private string lastName;
        private string firstName;
        private List<CardBox> cardBoxList;

        public int UserId
        {
            get => userId;
            set => userId = value;
        }
        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }
        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }
        internal List<CardBox> CardBoxList
        {
            get => cardBoxList;
            set => cardBoxList = value;
        }

    }
}
