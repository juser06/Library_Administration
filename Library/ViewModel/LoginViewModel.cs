using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string username;
        private string password;
        private string errorMessage;
        private bool isViewVisible = true;
    }
}
