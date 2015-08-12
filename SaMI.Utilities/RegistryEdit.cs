using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace SaMI.Utilities
{
    public class RegistryEdit
    {
        public String ApplicationName { get; set; }
        private bool showError = false;
        public bool ShowError
        {
            get { return showError; }
            set { showError = value; }
        }

        
        public string SubKey{get;set;}

        private RegistryKey baseRegistryKey = Registry.LocalMachine;
        public RegistryKey BaseRegistryKey
        {
            get { return baseRegistryKey; }
            set { baseRegistryKey = value; }
        }

        public RegistryEdit()
        {
            SubKey = "SOFTWARE\\" + ApplicationName.ToUpper();
        }

        public RegistryEdit(String strApplicationName)
        {
            ApplicationName = strApplicationName;
            SubKey = "SOFTWARE\\" + ApplicationName.ToUpper();
        }

        public string Read(string KeyName)
        {
            // Opening the registry key
            RegistryKey rk = baseRegistryKey;
            // Open a subKey as read-only
            RegistryKey sk1 = rk.OpenSubKey(SubKey);
            // If the RegistrySubKey doesn't exist -> (null)
            if (sk1 == null)
            {
                return null;
            }
            else
            {
                try
                {
                    // If the RegistryKey exists I get its value
                    // or null is returned.
                    return (string)sk1.GetValue(KeyName.ToUpper());
                }
                catch (Exception e)
                {
                    ShowErrorMessage(e, "Reading registry " + KeyName.ToUpper());
                    return null;
                }
            }
        }

        /* **************************************************************************
         * **************************************************************************/

        /// <summary>
        /// To write into a registry key.
        /// input: KeyName (string) , Value (object)
        /// output: true or false 
        /// </summary>
        public bool Write(string KeyName, object Value)
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                // I have to use CreateSubKey 
                // (create or open it if already exits), 
                // 'cause OpenSubKey open a subKey as read-only
                RegistryKey sk1 = rk.CreateSubKey(SubKey);
                // Save the value
                sk1.SetValue(KeyName.ToUpper(), Value);

                return true;
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, "Writing registry " + KeyName.ToUpper());
                return false;
            }
        }

        /* **************************************************************************
         * **************************************************************************/

        /// <summary>
        /// To delete a registry key.
        /// input: KeyName (string)
        /// output: true or false 
        /// </summary>
        public bool DeleteKey(string KeyName)
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.CreateSubKey(SubKey);
                // If the RegistrySubKey doesn't exists -> (true)
                if (sk1 == null)
                    return true;
                else
                    sk1.DeleteValue(KeyName);

                return true;
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, "Deleting SubKey " + SubKey);
                return false;
            }
        }

        /* **************************************************************************
         * **************************************************************************/

        /// <summary>
        /// To delete a sub key and any child.
        /// input: void
        /// output: true or false 
        /// </summary>
        public bool DeleteSubKeyTree()
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(SubKey);
                // If the RegistryKey exists, I delete it
                if (sk1 != null)
                    rk.DeleteSubKeyTree(SubKey);

                return true;
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, "Deleting SubKey " + SubKey);
                return false;
            }
        }

        /* **************************************************************************
         * **************************************************************************/

        /// <summary>
        /// Retrive the count of subkeys at the current key.
        /// input: void
        /// output: number of subkeys
        /// </summary>
        public int SubKeyCount()
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(SubKey);
                // If the RegistryKey exists...
                if (sk1 != null)
                    return sk1.SubKeyCount;
                else
                    return 0;
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, "Retriving subkeys of " + SubKey);
                return 0;
            }
        }

        /* **************************************************************************
         * **************************************************************************/

        /// <summary>
        /// Retrive the count of values in the key.
        /// input: void
        /// output: number of keys
        /// </summary>
        public int ValueCount()
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(SubKey);
                // If the RegistryKey exists...
                if (sk1 != null)
                    return sk1.ValueCount;
                else
                    return 0;
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, "Retriving keys of " + SubKey);
                return 0;
            }
        }

        /* **************************************************************************
         * **************************************************************************/

        private void ShowErrorMessage(Exception e, string Title)
        {
            //if (showError == true)
            //    MessageBox.Show(e.Message,
            //                    Title
            //                    , MessageBoxButtons.OK
            //                    , MessageBoxIcon.Error);
        }
    }
}
