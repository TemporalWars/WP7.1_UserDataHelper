using System;
using BenScharbach.WP7.Helpers.UserData.ViewModels;

namespace BenScharbach.WP7.Helpers.UserData.SampleData
{
    /// <summary>
    /// Populate sample data to Contacts Collection.
    /// </summary>
    static class ContactsSampleData
    {
        /// <summary>
        /// Populate with pretend sample data.
        /// </summary>
        public static void PopulateSampleData(ContactsHelper contactsHelper)
        {
            if (contactsHelper == null) throw new ArgumentNullException("contactsHelper");           
           
            // create some pretend 'Contact' data.       
            contactsHelper.Items.Add(new ContactViewModel() { ContactName = "Rick Gene" });
            contactsHelper.Items.Add(new ContactViewModel() { ContactName = "Lucy Sayer" });
            contactsHelper.Items.Add(new ContactViewModel() { ContactName = "Ele Mayo" });
            contactsHelper.Items.Add(new ContactViewModel() { ContactName = "Benny Dick" });
            contactsHelper.Items.Add(new ContactViewModel() { ContactName = "Lisa Gene" });
            contactsHelper.Items.Add(new ContactViewModel() { ContactName = "Lucy Fred" });
            contactsHelper.Items.Add(new ContactViewModel() { ContactName = "Fred Mayo" });
            contactsHelper.Items.Add(new ContactViewModel() { ContactName = "Benny Licker" });
            contactsHelper.Items.Add(new ContactViewModel() { ContactName = "Rick Stick" });
            contactsHelper.Items.Add(new ContactViewModel() { ContactName = "Mom Ti" });
            contactsHelper.Items.Add(new ContactViewModel() { ContactName = "Gabe Gib" });
            contactsHelper.Items.Add(new ContactViewModel() { ContactName = "Larry Rice" });
            
        }
    }
}
