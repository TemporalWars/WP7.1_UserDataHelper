using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;
using BenScharbach.WP7.Helpers.Storage;
using BenScharbach.WP7.Helpers.UserData.SampleData;
using BenScharbach.WP7.Helpers.UserData.ViewModels;
using Microsoft.Phone.UserData;

namespace BenScharbach.WP7.Helpers.UserData
{
    /// <summary>
    /// 
    /// </summary>
    public class ContactsHelper
    {
        private readonly Dispatcher _dispatcher;

        #region Properties

        /// <summary>
        /// A collection of my AddItem objects.
        /// </summary>
        public ObservableCollection<ContactViewModel> Items { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDataLoaded
        {
            get;
            private set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public ContactsHelper(Dispatcher dispatcher)
        {
            if (dispatcher == null) throw new ArgumentNullException("dispatcher");
            _dispatcher = dispatcher;

            Items = new ObservableCollection<ContactViewModel>();
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void LoadSampleData()
        {
            ClearData();
            ContactsSampleData.PopulateSampleData(this);
            IsDataLoaded = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void LoadData()
        {
            // get contacts
            var contacts = new Contacts();
            contacts.SearchCompleted += Contacts_SearchCompleted;
            contacts.SearchAsync("", FilterKind.None, null);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SaveDataToXML()
        {
            // iterate my Items collection and save as XML file.
            foreach (var contactViewModel in Items)
            {
                FileProcessor.SaveXmlSerializedStream(contactViewModel, "ContactsDataItem.xml");
                break; // jump ship from this iteration for testing.
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void LoadDataFromXML()
        {
            ContactViewModel contactViewModel;
            FileProcessor.LoadXmlSerializedStream("ContactsDataItem.xml", out contactViewModel);

            ClearData();
            Items.Add(contactViewModel);
            IsDataLoaded = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearData()
        {
            Items.Clear();
            IsDataLoaded = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            if (!e.Results.Any()) return;

            var contacts = e.Results;
            if (contacts == null) return;

            ClearData();

            //var progress = new BenScharbach.WPProgressHelper.Progress<Contact>(this, contacts);
            foreach (var contact in contacts)
            {
                if (contact == null) continue;

                _dispatcher.BeginInvoke(new Action<object>(AddViewItemModelCallback), contact);
            }

            IsDataLoaded = true;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void AddViewItemModelCallback(object obj)
        {
            var contact = obj as Contact;
            lock (Items)
            {
                Items.Add(new ContactViewModel { ContactName = contact.DisplayName, ContactItem = contact });
            }
        }
    }
}
