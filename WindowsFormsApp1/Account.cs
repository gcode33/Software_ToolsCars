using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Account
    {
        private int accountID;
        private string userName;
        private string password;
        private string email;
        private long phoneNumber;
        private string accountType;



        public Account()
        {
            this.accountID = 0;
            this.email = "";
            this.userName = "";
            this.email = "";
            this.phoneNumber = 0;
            this.accountType = "";
        }

        public Account(int accountID, string userName, string password, string email, long phoneNumber, string accountType)
        {
            this.accountID = accountID;
            this.userName = userName;
            this.password = password;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.accountType = accountType;
        }

        public int getAccountID() {  return this.accountID; }
        public string getUserName() { return this.userName;}
        public string getEmail() { return this.email;}
        public string getPassword() {  return this.password;}
        public long getPhoneNumber() { return this.phoneNumber;}
        public string getAccountType() {  return this.accountType;}


        public void setAccountType(string AccountType) { accountType = AccountType; }
        public void setPassword(string Password) { password = Password; }
        public void setEmail(string Email) {  email = Email; }
        public void setAccountID(int AccountID) { accountID = AccountID; }
        public void setUserName(string UserName) {  userName = UserName; }
        public void setPhoneNumber(long PhoneNumber) { phoneNumber = PhoneNumber; }
    }
}
