using CorePos.Blazor.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePos.Blazor.Services
{
    public class AppState
    {
        public AppState()
        {
            _loggedIn = false;
        }

        private bool _loggedIn;
        public event Action OnChange;
        public bool LoggedIn
        {
            get { return _loggedIn; }
            set
            {
                if (_loggedIn != value)
                {
                    _loggedIn = value;
                    NotifyStateChanged();
                }
            }
        }
        private void NotifyStateChanged() => OnChange?.Invoke();

        public List<CorePOSApi.Model.SaleMd> sales = null;
        public List<CorePOSApi.Model.ReferenceMd> references = null;
        public CorePOSApi.Model.contract.LoginResponse loginResponse = null;

        public int wareHouseId
        {
            get
            {
                if( loginResponse != null )
                {
                    return loginResponse.wareHouseId;
                }
                else
                {
                    return -1;
                }
            }
        }

    }
}
