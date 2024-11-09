namespace BlazorApp1.Services
{
	public class UserStateService
	{
		public string UserRole { get; set; }

        private bool _isUserLoggedIn = false;
        public bool IsUserLoggedIn
        {
            get => _isUserLoggedIn;
            set
            {
                if (_isUserLoggedIn != value)
                {
                    _isUserLoggedIn = value;
                    OnUserStateChanged?.Invoke();
                }
            }
        }

        public event Action? OnUserStateChanged;

        public void LogIn(string userName)
        {
            IsUserLoggedIn = true;
        }

        public void LogOut()
        {
            IsUserLoggedIn = false;
        }
    }
}
